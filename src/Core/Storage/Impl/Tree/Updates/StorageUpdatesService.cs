using Core.Storage.Interfaces;
using Core.Storage.Interfaces.Updates;
using Microsoft.Extensions.Logging;

namespace Core.Storage.Impl.Tree.Updates;

public class StorageUpdatesService(ILogger<StorageUpdatesService> logger, IStorageRepository<uint> repository)
    : IStorageUpdatesService<uint>
{
    private readonly Queue<StorageUpdate> _changes = [];

    public void OnUpdate(IStorageUpdate<uint> update)
    {
        _changes.Enqueue((StorageUpdate)update);
        
        logger.LogDebug("Adding new update to changes queue");
    }

    public void Commit()
    {
        logger.LogDebug("Commit data structure updates to repository..");

        const string message = "  --> {0}.. {1}";
        
        do
        {
            var update = _changes.Peek();
 
            if (repository.ApplyUpdate(update))
            {
                logger.LogDebug(message, update, "ok");
                _changes.Dequeue();
            }
            else
            {
                logger.LogError(message, update, "not ok");
                break;
            }
        } 
        while (_changes.Count > 0);
    }
}