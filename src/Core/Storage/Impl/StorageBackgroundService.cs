using Core.Storage.Interfaces;
using Core.Storage.Interfaces.Tasks;
using Core.Storage.Interfaces.Operations;
using Core.Storage.Impl.Tree.Trees;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using Core.Storage.Impl.Tree;

namespace Core.Storage.Impl;

public class StorageBackgroundService(
    IStorageService service,
    IStorageRepository repository,
    IBinaryTree tree,
    ILogger<StorageBackgroundService> logger)
    : BackgroundService
{
    private readonly ConcurrentQueue<IStorageTask> _tasks = service.Tasks;

    protected override Task<Task> ExecuteAsync(CancellationToken stoppingToken)
    {
        var generator = repository.CommittedOperationsEnumerator();
        AcceptStateBy(generator);
        
        logger.LogInformation("State of data structure is restored ");
        
        return Task.FromResult(Task.Run(() => BackgroundProcessing(stoppingToken), stoppingToken));
    }

    private async void BackgroundProcessing(CancellationToken stoppingToken)
    {
        logger.LogDebug("Startup background queue processing");

        while (!stoppingToken.IsCancellationRequested)
        {
            while (!_tasks.IsEmpty)
            {
                if (!_tasks.TryPeek(out var task)) continue;
                
                logger.LogDebug("New task: {task}. started to process..", task);
                
                var (isSuccess, payload) = await ProcessTask(task);

                task.Payload = payload;
                
                if (isSuccess)
                {
                    _tasks.TryDequeue(out var _);
                    logger.LogDebug("Task completed successfully");
                }
                else
                {
                    task.IsSuccess = false;
                    _tasks.TryDequeue(out var _);
                    logger.LogCritical("Error in this task processing: {task}", task);
                }
            }

            await Task.Delay(10, stoppingToken);
        }
    }
    
    private async Task<Tuple<bool, string?>> ProcessTask(IOperation task)
    {
        var isCommitted = await repository.CommitOperation(task);

        if (!isCommitted)
            return new Tuple<bool, string?>(false, null);

        var payload = await ProcessOperation(task);
        
        return new Tuple<bool, string?>(true, payload);
    }

    private Task<string?> ProcessOperation(IOperation operation)
    {
        switch (operation.OperationType)
        {
            case OperationType.Insert:
            {
                tree.Insert(SplayTree.CreateNode(operation.Key, operation.Payload!));
                break;
            }
            case OperationType.Search:
            {
                var node = tree.Search(operation.Key);
                return Task.FromResult(node?.Value);
            }
            case OperationType.Delete:
            {
                tree.Delete(operation.Key);
                break;
            }
        }

        return Task.FromResult<string?>(null);
    }

    private async void AcceptStateBy(IEnumerator<Operation> generator)
    {
        while (generator.MoveNext())
        {
            await ProcessOperation(generator.Current);
        }
    }
}