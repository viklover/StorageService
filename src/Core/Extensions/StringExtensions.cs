using Core.Storage.Impl.Tree.Entities;
using Core.Storage.Impl.Tree.Entities.Nodes;

namespace Core.Extensions;

public static class StringExtensions
{
    public static int CompareKeys(this string key, INode? node)
    {
        return node == null ? 1 : Node.CompareKeys(key, node.Key);
    }
}