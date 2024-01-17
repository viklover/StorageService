using Core.Storage.Interfaces.Updates;

namespace Core.Storage.Impl.Tree.Updates;

public class StorageUpdatesService : IStorageUpdatesService<uint>
{
    private LinkedList<StorageUpdate> _changes = [];
    
    public void Add(IStorageUpdate<uint> update)
    {
        throw new NotImplementedException();
    }

    public bool Commit()
    {
        throw new NotImplementedException();
    }
}