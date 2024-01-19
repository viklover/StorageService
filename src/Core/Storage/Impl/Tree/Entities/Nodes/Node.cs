namespace Core.Storage.Impl.Tree.Entities.Nodes;

/// <summary>
/// Node of splay tree
/// represents a pair in storage service 
/// </summary>
/// <param name="key">Hash of variable name</param>
/// <param name="value">Variable value</param>
public class Node(string key, string value) : INode
{
    public INode? Parent { get; set; }
    public INode? Left { get; set; }
    public INode? Right { get; set; }

    public string Key { get; } = key;
    public string Value { get; set; } = value;

    /// <summary>
    /// Find out the relationship between node A and node B
    /// </summary>
    /// <param name="node">Node to analyzing</param>
    /// <returns>Relation type</returns>
    public RelationType CheckRelationBy(INode? node)
    {
        if (node == null)
            return RelationType.None;

        if (Left != null && Left.Key == node.Key)
            return RelationType.LeftChild;

        if (Right != null && Right.Key == node.Key)
            return RelationType.RightChild;

        return RelationType.None;
    }
    
    public int CompareTo(INode? other)
    {
        return other == null ? 1 : Node.CompareKeys(Key, other.Key);
    }

    /// <summary>
    /// Comparing node keys. It's important to tree formation
    /// </summary>
    /// <param name="key1">First key</param>
    /// <param name="key2">Second key</param>
    /// <returns>0 -> keys are equal, -1 -> key2 is greater than key1, 1 -> key1 is greater than key2</returns>
    public static int CompareKeys(string key1, string key2)
    {
        return string.Compare(key1, key2, StringComparison.Ordinal);
    }
}