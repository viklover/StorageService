using Core.Infrastructure;
using Core.Storage.Interfaces.Updates;

namespace Core.Storage.Impl.Tree.Updates;

public class StorageUpdatesService : IStorageUpdatesService<uint>
{
    private readonly Queue<StorageUpdate> _changes = [];
    private readonly IStorageRepository<uint> _repository;

    public StorageUpdatesService(IStorageRepository<uint> repository)
    {
        _repository = repository;
        _repository.PrepareSchemas();
    }

    public void OnUpdate(IStorageUpdate<uint> update)
    {
        _changes.Enqueue((StorageUpdate) update);
    }

    public bool Commit()
    {
        return false;
    }
}