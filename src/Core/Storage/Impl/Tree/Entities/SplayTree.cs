using Core.Storage.Impl.Tree.Utils;

namespace Core.Storage.Impl.Tree.Entities;

public class SplayTree
{
    private Node? _root;

    /// <summary>
    /// Inserting a new node in the tree
    /// </summary>
    /// <param name="newNode">Node that has to be inserted</param>
    /// <param name="wasUpdated">Existing node was updated?</param>
    /// <returns>Inserted or updated node instance</returns>
    public Node Insert(Node newNode, out bool wasUpdated)
    {
        wasUpdated = false;

        if (_root == null)
            return _root = newNode;
        
        // found node or closest (by key) node
        var node = SplayTreeOperations.TreeSearch(_root, newNode.Key)!;
        
        // splay this node
        Splay(node);
        
        // update node if node with this key already exists
        if (node.Key == newNode.Key)
        {
            node.Value = newNode.Value;
            wasUpdated = true;
            return node;
        }

        // insert node with changing root of tree
        if (node.Key < newNode.Key)
        {
            newNode.Left = node;
            newNode.Right = node.Right;
            node.Right = null;
            node.Parent = newNode;
        }
        else
        {
            newNode.Right = node;
            newNode.Left = node.Left;
            node.Left = null;
            node.Parent = newNode;
        }

        newNode.Parent = null;

        return _root = newNode;
    }

    /// <summary>
    /// Searching a node by key
    /// </summary>
    /// <param name="key">Node key</param>
    /// <returns>Found node or null</returns>
    public Node? Search(uint key)
    {
        var node = SplayTreeOperations.TreeSearch(_root, key);

        if (node == null)
            return null;

        Splay(node);

        return node.Key != key ? null : node;
    }

    /// <summary>
    /// Delete a node by key
    /// </summary>
    /// <param name="key">Node key</param>
    /// <returns>"true" if node has been deleted otherwise - "false"</returns>
    public bool Delete(uint key)
    {
        var node = Search(key);

        if (node == null)
            return false;
        
        // deleting node and concat other branches
        if (node.Left == null && node.Right == null)
        {
            _root = null;
        }
        else if (node.Left != null && node.Right == null)
        {
            _root = node.Left;
            _root.Parent = null;
        }
        else if (node.Right != null && node.Left == null)
        {
            _root = node.Right;
            _root.Parent = null;
        }
        else if (node.Right != null && node.Left != null)
        {
            var minimumNode = SplayTreeOperations.TreeSearchMinimum(node.Right)!;
            _root = SplayTreeOperations.Splay(minimumNode)!;
            _root.Parent = null;

            _root.Left = node.Left;
            _root.Left.Parent = _root;
        }

        return true;
    }
    
    /// <summary>
    /// Splaying operation with root of splay tree
    /// </summary>
    /// <param name="node">Search node</param>
    /// <returns>New root of tree</returns>
    private Node? Splay(Node node)
    {
        return _root = SplayTreeOperations.Splay(node);
    }
}
