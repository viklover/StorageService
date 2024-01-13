namespace Core.Storage.Impl.SplayTree.Entities;

public class Node(uint key, string value)
{
    public Node? Parent { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }

    public uint Key { get; } = key;
    public string Value { get; set; } = value;
}