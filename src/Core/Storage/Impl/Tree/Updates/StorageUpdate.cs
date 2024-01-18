using Core.Storage.Interfaces;
using Core.Storage.Interfaces.Updates;
using Core.Storage.Interfaces.Updates.Types;

namespace Core.Storage.Impl.Tree.Updates;

/// <summary>
/// Storage update entity for splay tree implementation service 
/// </summary>
public class StorageUpdate : IStorageUpdate
{
    public List<Tuple<IPair, PairUpdateType>> Pairs()
    {
        throw new NotImplementedException();
    }
}