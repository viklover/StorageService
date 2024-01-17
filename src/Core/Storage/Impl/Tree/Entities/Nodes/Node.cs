namespace Core.Storage.Impl.Tree.Entities.Nodes;

/// <summary>
/// Node of splay tree
/// represents a pair in storage service 
/// </summary>
/// <param name="key">Hash of variable name</param>
/// <param name="value">Variable value</param>
public class Node(uint key, string value) : INode
{
    public INode? Parent { get; set; }
    public INode? Left { get; set; }
    public INode? Right { get; set; }

    public uint Key { get; } = key;
    public string Value { get; set; } = value;
}