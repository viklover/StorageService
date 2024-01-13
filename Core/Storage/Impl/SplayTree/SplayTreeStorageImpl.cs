namespace Core.Storage.Impl.SplayTree;

using Entities;
using Extensions;

public class SplayTreeStorageImpl : IStorageService
{
    private readonly SplayTree _tree = new SplayTree();
    
    public void SaveOrUpdatePair(string key, string value)
    {
        _tree.Insert(SplayTree.CreateNode(key.Hash(), value), out var wasUpdated);
    }

    public string? GetValueByKey(string key)
    {
        return _tree.Search(key.Hash())?.Value;
    }

    public void DeletePairByKey(string key)
    {
        _tree.Delete(key.Hash());
    }
}