namespace Core.Storage.Impl.Tree.Entities;

/// <summary>
/// Splay tree data structure.
/// Can be implement like top-down or bottom-up
/// </summary>
public interface ISplayTree
{
    INode? Root { get; }
    
    /// <summary>
    /// Searching a node by key
    /// </summary>
    /// <param name="key">Node key</param>
    /// <returns>Found node or null</returns>
    INode? Search(uint key);
    
    /// <summary>
    /// Inserting a new node in the tree
    /// </summary>
    /// <param name="newNode">Node that has to be inserted</param>
    /// <returns>Inserted or updated node instance</returns>
    INode Insert(INode newNode);

    /// <summary>
    /// Delete a node by key
    /// </summary>
    /// <param name="key">Node key</param>
    /// <returns>"true" if node has been deleted otherwise - "false"</returns>
    bool Delete(uint key);
}