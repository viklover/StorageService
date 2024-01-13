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
    /// Splaying operation to root node by 
    /// </summary>
    /// <param name="root"></param>
    /// <param name="x"></param>
    /// <returns></returns>
    public static Node? Splay(Node? root, Node x)
    {
        if (root == null || root.Key == x.Key)
            return root;

        if (root.Key > x.Key)
        {
            if (root.Left == null)
                return root;

            if (root.Left.Key > x.Key)
            {
                root.Left.Left = Splay(root.Left.Left, x);
                root = Zig(root);
            }
            else if (root.Left.Key < x.Key)
            {
                root.Left.Right = Splay(root.Left.Right, x);
                if (root.Left.Right != null)
                    root.Left = Zag(root.Left); // result: root.Left can be null now
            }

            return (root.Left == null) ? root : Zig(root);
        }
        else
        {
            if (root.Right == null)
                return root;

            if (root.Right.Key > x.Key)
            {
                root.Right.Left = Splay(root.Right.Left, x);

                if (root.Right.Left != null)
                    root.Right = Zig(root.Right);
            }
            else if (root.Right.Key < x.Key)
            {
                root.Right.Right = Splay(root.Right.Right, x);
                root = Zag(root); // result: root.Left can be null now
            }

            return (root.Right == null) ? root : Zag(root);
        }
    }
    //TODO: using iteration method instead of recursion
}