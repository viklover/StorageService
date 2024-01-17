using Core.Infrastructure;
using Core.Storage.Interfaces.Updates;

namespace Core.Storage.Impl.Tree.Updates;

public class StorageUpdatesService : IStorageUpdatesService<uint>
{
    private readonly LinkedList<StorageUpdate> _changes = [];
    private readonly IStorageRepository _repository;

    public StorageUpdatesService(IStorageRepository repository)
    {
        _repository = repository;
        _repository.PrepareSchemas();
    }

    public void OnUpdate(IStorageUpdate<uint> update)
    {
        _changes.AddLast((StorageUpdate) update);
    }

    public bool Commit()
    {
        throw new NotImplementedException();
    }
}