using Core.Storage.Interfaces;
using Core.Storage.Interfaces.Updates;

namespace Core.Storage.Impl.Tree.Updates;

public class StorageUpdate : IStorageUpdate<uint>
{
    public List<Tuple<IPair<uint>, PairUpdateType>> Pairs()
    {
        throw new NotImplementedException();
    }
}