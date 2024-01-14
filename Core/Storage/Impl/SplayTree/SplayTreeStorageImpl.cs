namespace Core.Storage.Impl.SplayTree;

using Entities;
using Extensions;

public class SplayTreeStorageImpl : IStorageService
{
    private readonly SplayTree _tree = new SplayTree();
    
    public void SaveOrUpdatePair(string key, string value)
    {
        _tree.Insert(SplayTreeOperations.CreateNode(key.Hash(), value), out var wasUpdated);
    }

    public string? GetValueByKey(string key)
    {
        return _tree.Search(key.Hash())?.Value;
    }

    public bool DeletePairByKey(string key)
    {
        return _tree.Delete(key.Hash());
    }
}