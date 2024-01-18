using Core.Storage.Interfaces.Updates.Types;

namespace Core.Storage.Impl.Tree.Entities;

/// <summary>
/// Interface of binary tree data structure.
/// </summary>
public interface IBinaryTree
{
    INode? Root { get; }
    
    /// <summary>
    /// Searching a node by key
    /// </summary>
    /// <param name="key">Node key</param>
    /// <returns>Found node or null</returns>
    INode? Search(string key);
    
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
    bool Delete(string key);
    
    /// <summary>
    /// Updates channel for event subscribers
    /// </summary>
    event StorageUpdateHandler UpdatesChannel;
}