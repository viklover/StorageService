using Core.Storage.Impl.Tree.Utils;

namespace Core.Storage.Impl.Tree.Entities;

public class SplayTree
{
    public Node? root { get; private set; }

    /// <summary>
    /// Inserting a new node in the tree
    /// </summary>
    /// <param name="newNode">Node that has to be inserted</param>
    /// <param name="wasUpdated">Existing node was updated?</param>
    /// <returns>Inserted or updated node instance</returns>
    public Node Insert(Node newNode, out bool wasUpdated)
    {
        wasUpdated = false;

        if (root == null)
            return root = newNode;
        
        // found node or closest (by key) node
        var node = SplayTreeOperations.TreeSearch(root, newNode.Key)!;
        
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
            newNode.Left.Parent = newNode;
            newNode.Right = node.Right;
            
            if (newNode.Right != null) 
                newNode.Right.Parent = newNode;
            
            node.Right = null;
            node.Parent = newNode;
        }
        else
        {
            newNode.Right = node;
            newNode.Right.Parent = newNode;
            newNode.Left = node.Left;

            if (newNode.Right != null)
                newNode.Right.Parent = newNode;
            
            node.Left = null;
            node.Parent = newNode;
        }

        newNode.Parent = null;

        return root = newNode;
    }

    /// <summary>
    /// Inserting a new node in the tree
    /// </summary>
    /// <param name="newNode">Node that has to be inserted</param>
    /// <returns>Inserted or updated node instance</returns>
    public Node Insert(Node newNode) => Insert(newNode, out var value);
    
    /// <summary>
    /// Searching a node by key
    /// </summary>
    /// <param name="key">Node key</param>
    /// <returns>Found node or null</returns>
    public Node? Search(uint key)
    {
        var node = SplayTreeOperations.TreeSearch(root, key);

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
            root = null;
        }
        else if (node.Left != null && node.Right == null)
        {
            root = node.Left;
            root.Parent = null;
        }
        else if (node.Right != null && node.Left == null)
        {
            root = node.Right;
            root.Parent = null;
        }
        else if (node.Right != null && node.Left != null)
        {
            var minimumNode = SplayTreeOperations.TreeSearchMinimum(node.Right)!;
            root = SplayTreeOperations.Splay(minimumNode)!;
            root.Parent = null;

            root.Left = node.Left;
            root.Left.Parent = root;
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
        return root = SplayTreeOperations.Splay(node);
    }
}
