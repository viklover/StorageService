using Core.Storage.Impl.Tasks;
using Core.Storage.Interfaces;
using Core.Storage.Interfaces.Tasks;
using Core.Storage.Interfaces.Operations;

using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace Core.Storage.Impl;

public class SplayTreeStorageService(ILogger<SplayTreeStorageService> logger) : IStorageService
{
    public ConcurrentQueue<IStorageTask> Tasks { get; } = new();

    public Task SavePairAsync(string key, string value)
    {
        var task = new StorageTask(OperationType.Insert, key, value);
        
        AddTaskToQueue(task);
        
        return Task.CompletedTask;
    }

    public async Task<string?> GetValueByKey(string key)
    {
        var task = new StorageTask(OperationType.Search, key);
        
        AddTaskToQueue(task);
        
        var result = await WaitResult(task);
        return result.Payload;
    }

    public Task DeletePairByKeyAsync(string key)
    {
        var task = new StorageTask(OperationType.Delete, key);
        
        AddTaskToQueue(task);
        
        return Task.CompletedTask;
    }

    private void AddTaskToQueue(IStorageTask task)
    {
        Tasks.Enqueue(task);
        
        logger.LogDebug("Task was added: {task}", task);
    }
    
    private async Task<IStorageTask> WaitResult(IStorageTask operation)
    {
        return await Task.Run(async () =>
        {
            while (true)
            {
                if (!Tasks.Contains(operation))
                    return operation;
                
                await Task.Delay(50);
            }
        });
    }
}