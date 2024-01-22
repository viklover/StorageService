using Core.Exceptions;
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

    public void SavePairAsync(string key, string value)
    {
        var task = new StorageTask(OperationType.Insert, key, value);
        AddTaskToQueue(task);
    }

    public async Task<string?> GetValueByKey(string key)
    {
        var task = new StorageTask(OperationType.Search, key);
        AddTaskToQueue(task);
        
        var result = await WaitResult(task);
        
        return result.Payload;
    }

    public void DeletePairByKeyAsync(string key)
    {
        var task = new StorageTask(OperationType.Delete, key);
        AddTaskToQueue(task);
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
            var currentTime = DateTimeOffset.Now.ToUnixTimeSeconds();
            
            while (Tasks.Contains(operation))
            {
                var delay = DateTimeOffset.Now.ToUnixTimeSeconds() - currentTime;
                
                if (delay > 30)
                    throw new TimeoutOccuredException();

                await Task.Delay(10); // heh, 'how to save SOH'
            }
            
            return operation;
        });
    }
}