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
    
    public int CompareTo(INode? other)
    {
        return other == null ? 1 : string.Compare(Key, Value, StringComparison.Ordinal);
    }
}