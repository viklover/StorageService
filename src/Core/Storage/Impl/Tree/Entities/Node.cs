namespace Core.Storage.Impl.Tree.Entities;

/// <summary>
/// Node of splay tree
/// represents a pair in storage service 
/// </summary>
/// <param name="key">Hash of variable name</param>
/// <param name="value">Variable value</param>
public class Node(uint key, string value)
{
    public Node? Parent { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }

    public uint Key { get; } = key;
    public string Value { get; set; } = value;
}