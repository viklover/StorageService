namespace Core.Storage.Impl.SplayTree.Entities;

/// <summary>
/// Splay Tree Operations utility class.
/// Represents a generic binary tree business logic
/// </summary>
public static class SplayTreeOperations
{
    /// <summary>
    /// Creating a new node instance
    /// </summary>
    /// <param name="key">Node key</param>
    /// <param name="value">Node value</param>
    /// <returns>Node instance</returns>
    public static Node CreateNode(uint key, string value) => new Node(key, value);

    /// <summary>
    /// Right rotation in splay tree
    /// </summary>
    /// <param name="x">Node that will be lowered by left child node</param>
    /// <exception cref="NullReferenceException">If left child is null</exception>
    /// <returns>Formed connections between nodes</returns>
    public static Node Zig(Node x)
    {
        var y = x.Left;
        x.Left = y!.Right;
        y.Right = x;
        return y;
    }
    
    /// <summary>
    /// Left rotation in splay tree
    /// </summary>
    /// <param name="x">Node that will be lowered by right child node</param>
    /// <exception cref="NullReferenceException">If right child is null</exception>
    /// <returns>Formed connections between nodes</returns>
    public static Node Zag(Node x)
    {
        var y = x.Right;
        x.Right = y!.Left;
        y.Left = x;
        return y;
    }

    /// <summary>
    /// Searching for a node instance in the tree by key
    /// </summary>
    /// <param name="root">Root of tree</param>
    /// <param name="key">Node key</param>
    /// <returns>Found node or closest parent or null</returns>
    public static Node? TreeSearch(Node? root, uint key)
    {
        if (root == null)
            return null;
        
        var ptr = root;
        
        do
        {
            if (key < ptr.Key)
            {
                if (ptr.Left == null)
                    return ptr;
                
                ptr = ptr.Left;
            }
            else if (key > ptr.Key)
            {
                if (ptr.Right == null)
                    return ptr;
                
                ptr = ptr.Right;
            }
            else
            {
                return ptr;
            }
            
        } while (ptr != null);

        return null;
    }

    /// <summary>
    /// Splaying operation to search node
    /// </summary>
    /// <param name="x">Search node</param>
    /// <exception cref="Exception">Throws when tree consistency is broken or author is dumb</exception>
    /// <returns>New root of tree - search node</returns>
    public static Node? Splay(Node x)
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
}