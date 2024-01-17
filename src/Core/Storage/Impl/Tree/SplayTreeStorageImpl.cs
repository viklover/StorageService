using Core.Storage.Impl.Tree.Entities.SplayTrees;
using Core.Storage.Interfaces;
using Core.Infrastructure;

namespace Core.Storage.Impl.Tree;

using Entities;
using Extensions;

public class SplayTreeStorageImpl : IStorageService
{
    private readonly ISplayTree _tree = new SplayTree();
    private readonly IStorageRepository _repository;

    public SplayTreeStorageImpl(IStorageRepository repository)
    {
        _repository = repository;
        _repository.PrepareSchemas();
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