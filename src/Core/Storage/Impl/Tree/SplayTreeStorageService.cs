using Core.Storage.Interfaces;
using Core.Storage.Interfaces.Updates;

using Core.Storage.Impl.Tree.Entities.Trees;

namespace Core.Storage.Impl.Tree;

using Entities;

public class SplayTreeStorageService : IStorageService
{
    private readonly IBinaryTree _tree = new SplayTree();
    private readonly IStorageUpdatesService _updatesService;

    public SplayTreeStorageService(IStorageUpdatesService updatesService)
    {
        _tree.UpdatesChannel += updatesService.OnUpdate;
        _updatesService = updatesService;
    }

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