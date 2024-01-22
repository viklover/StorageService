namespace Core.Storage.Impl.Tree;

/// <summary>
/// Interface of tree node.
/// It's pair in storage service area.
/// </summary>
public interface INode : IComparable<INode>
{
    INode? Parent { get; set; }
    INode? Left { get; set; }
    INode? Right { get; set; }
    
    public string Key { get; }
    public string Value { get; set; }

    /// <summary>
    /// Get relationship type between nodes
    /// </summary>
    /// <returns>Relation type</returns>
    RelationType CheckRelationBy(INode? node);
}