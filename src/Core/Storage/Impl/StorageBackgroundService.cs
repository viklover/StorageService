using Core.Storage.Interfaces;
using Core.Storage.Interfaces.Tasks;
using Core.Storage.Interfaces.Operations;
using Core.Storage.Impl.Tree.Trees;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Core.Storage.Impl;

public class StorageBackgroundService(
    IStorageService service,
    IStorageRepository repository,
    ILogger<StorageBackgroundService> logger)
    : BackgroundService
{
    private readonly SplayTree _tree = new();

    private readonly ConcurrentQueue<IStorageTask> _tasks = service.Tasks;

    protected override Task<Task> ExecuteAsync(CancellationToken stoppingToken)
    {
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

                ProcessTask(task);
                _tasks.TryDequeue(out var _);

                logger.LogDebug("Task completed successfully");
            }

            await Task.Delay(50, stoppingToken);
        }
    }

    private void ProcessTask(IStorageTask task)
    {
        switch (task.OperationType)
        {
            case OperationType.Insert:
            {
                // TODO: attempt writing event in event store
                _tree.Insert(SplayTree.CreateNode(task.Key, task.Payload!));
                break;
            }
            case OperationType.Search:
            {
                // TODO: attempt writing event in event store
                var node = _tree.Search(task.Key);
                if (node != null)
                    task.Payload = node.Value;
                break;
            }
            case OperationType.Delete:
            {
                // TODO: attempt writing event in event store
                _tree.Delete(task.Key);
                break;
            }
        }
    }

    public void AcceptStateBy(IEnumerator<string> generator)
    {
        // TODO: event sourcing task
    }
}