using Core.Storage.Interfaces;

namespace Core.Storage.Impl.Tree;

using Entities.Trees;

public class SplayTreeStorageService : IStorageService
{
    private readonly SplayTree _tree = new SplayTree();

    public void SaveOrUpdatePair(string key, string value)
    {
        _tree.Insert(SplayTree.CreateNode(key, value));
    }

    public string? GetValueByKey(string key)
    {
        return _tree.Search(key)?.Value;
    }

    public bool DeletePairByKey(string key)
    {
        return _tree.Delete(key);
    }
}