using Core.Storage.Impl.Tree.Entities.Nodes;
using Core.Storage.Interfaces.Updates.Types;

namespace Core.Storage.Impl.Tree.Entities.Trees;

/// <summary>
/// Splay tree (bottom-up implementation) - binary search tree
/// </summary>
public class SplayTree : IBinaryTree
{
    public INode? Root { get; private set; }

    /// <summary>
    /// Searching a node by key
    /// </summary>
    /// <param name="key">Node key</param>
    /// <returns>Found node or null</returns>
    public INode? Search(string key)
    {
        var node = TreeSearch(key);

        if (node == null)
            return null;

        Splay(node);

        return node.Key != key ? null : node;
    }

    /// <summary>
    /// Inserting a new node in the tree
    /// </summary>
    /// <param name="newNode">Node that has to be inserted</param>
    /// <returns>Inserted or updated node instance</returns>
    public INode Insert(INode newNode)
    {
        if (Root == null)
            return Root = newNode;
        
        // found node or closest (by key) node
        var node = TreeSearch(newNode.Key)!;
        
        // splay this node
        Splay(node);
        
        // update node if node with this key already exists
        if (node.Key == newNode.Key)
        {
            node.Value = newNode.Value;
            return node;
        }

        // insert node with changing root of tree
        if (node.CompareTo(newNode) < 0)
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

            if (newNode.Left != null)
                newNode.Left.Parent = newNode;
            
            node.Left = null;
            node.Parent = newNode;
        }

        newNode.Parent = null;

        return Root = newNode;
    }

    /// <summary>
    /// Delete a node by key
    /// </summary>
    /// <param name="key">Node key</param>
    /// <returns>"true" if node has been deleted otherwise - "false"</returns>
    public bool Delete(string key)
    {
        var node = Search(key);

        if (node == null)
            return false;
        
        // deleting node and concat other branches
        if (node.Left == null && node.Right == null)
        {
            Root = null;
        }
        else if (node.Left != null && node.Right == null)
        {
            Root = node.Left;
            Root.Parent = null;
        }
        else if (node.Right != null && node.Left == null)
        {
            Root = node.Right;
            Root.Parent = null;
        }
        else if (node.Right != null && node.Left != null)
        {
            var minimumNode = TreeSearchMinimum(node.Right)!;
            Root = Splay(minimumNode)!;
            Root.Parent = null;

            Root.Left = node.Left;
            Root.Left.Parent = Root;
        }

        return true;
    }
    
    /// <summary>
    /// Creating a new node instance
    /// </summary>
    /// <param name="key">Node key</param>
    /// <param name="value">Node value</param>
    /// <returns>Node instance</returns>
    public static INode CreateNode(string key, string value) => new Node(key, value);

    /// <summary>
    /// Splaying operation to search node
    /// </summary>
    /// <param name="x">Search node</param>
    /// <exception cref="Exception">Throws when tree consistency is broken or author is dumb</exception>
    /// <returns>New root of tree - search node</returns>
    private INode? Splay(INode x)
    {
        if (x.Parent == null)
            return x;

        var i = x;
        
        do
        {
            if (i.Parent.Left != null && i.Parent.Left.Key == x.Key)
            {
                i = Zig(i.Parent);
            }
            else if (i.Parent.Right != null && i.Parent.Right.Key == x.Key)
            {
                i = Zag(i.Parent);
            }
            else
            {
                throw new Exception("Error in Splay Operation: consistency is probably broken");
            }
            
        } while (i.Parent != null);

        return i;
    }
    
    /// <summary>
    /// Right rotation in splay tree
    /// </summary>
    /// <param name="x">Node that will be lowered by left child node</param>
    /// <exception cref="NullReferenceException">If left child is null</exception>
    /// <returns>Formed connections between nodes</returns>
    private INode Zig(INode x)
    {
        var y = x.Left!;
        x.Left = y.Right;

        if (y.Right != null)
            y.Right.Parent = x;

        y.Parent = x.Parent;

        if (x == x.Parent?.Right)
            x.Parent.Right = y;
        else if (x == x.Parent?.Left)
            x.Parent.Left = y;
            
        y.Right = x;
        x.Parent = y;
        return y;
    }
    
    /// <summary>
    /// Left rotation in splay tree
    /// </summary>
    /// <param name="x">Node that will be lowered by right child node</param>
    /// <exception cref="NullReferenceException">If right child is null</exception>
    /// <returns>Formed connections between nodes</returns>
    private INode Zag(INode x)
    {
        var y = x.Right!;
        x.Right = y.Left;

        if (y.Left != null)
            y.Left.Parent = x;

        y.Parent = x.Parent;

        if (x == x.Parent?.Left)
            x.Parent.Left = y;
        else if (x == x.Parent?.Right)
            x.Parent.Right = y;
        
        y.Left = x;
        x.Parent = y;
        return y;
    }

    /// <summary>
    /// Searching for a node instance in the tree by key
    /// </summary>
    /// <param name="root">Root node of tree</param>
    /// <param name="key">Node key</param>
    /// <returns>Found node or closest parent or null</returns>
    private INode? TreeSearch(string key)
    {
        var ptr = Root;
        
        while (ptr != null)
        {
            if (key.CompareTo(ptr) < 0)
            {
                if (ptr.Left == null)
                    return ptr;
                
                ptr = ptr.Left;
            }
            else if (key.CompareTo(ptr) > 0)
            {
                if (ptr.Right == null)
                    return ptr;
                
                ptr = ptr.Right;
            }
            else
            {
                return ptr;
            }
        }

        return null;
    }

    /// <summary>
    /// Searching a minimum node in the tree
    /// </summary>
    /// <param name="root">Root node of tree</param>
    /// <returns>Minimum node</returns>
    private INode? TreeSearchMinimum(INode node)
    {
        var i = node;

        while (i.Left != null) i = i.Left;

        return i;
    }
    
    public event StorageUpdateHandler? UpdatesChannel;
}
