using Core.Storage.Interfaces;
using Core.Storage.Interfaces.Updates;

using Core.Storage.Impl.Tree.Entities.SplayTrees;

namespace Core.Storage.Impl.Tree;

using Entities;
using Extensions;

public class SplayTreeStorageService : IStorageService
{
    private readonly IBinaryTree _tree = new SplayTree();
    private readonly IStorageUpdatesService<uint> _updatesService;

    public SplayTreeStorageService(IStorageUpdatesService<uint> updatesService)
    {
        _tree.UpdatesChannel += updatesService.OnUpdate;
        _updatesService = updatesService;
    }

    public void SaveOrUpdatePair(string key, string value)
    {
        _tree.Insert(SplayTree.CreateNode(key.Hash(), value));
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