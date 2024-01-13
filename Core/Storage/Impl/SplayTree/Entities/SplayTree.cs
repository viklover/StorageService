namespace Core.Storage.Impl.SplayTree.Entities;

public class SplayTree
{
    private Node? _root;
    
    public static Node CreateNode(uint key, string value) => new Node(key, value);

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
        
        var node = TreeSearch(newNode.Key)!;
        
        // new node with this key already exists
        if (node.Key == newNode.Key)
        {
            node.Value = newNode.Value;
            wasUpdated = true;
            return Splay(node);
        } 
        
        // found node is parent for new node
        if (newNode.Key < node.Key)
            node.Left = newNode;
        else
            node.Right = newNode;

        return Splay(newNode);
    }

    /// <summary>
    /// Searching a node by key
    /// </summary>
    /// <param name="key">Node key</param>
    /// <returns>Found node or null</returns>
    public Node? Search(uint key)
    {
        var node = TreeSearch(key);

        if (node == null)
            return null;

        // поднимаем найденную ноду
        // (или ближайшую ноду, которая могла бы быть родителем для поискового ключа)
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
        var node = TreeSearch(key);

        if (node == null)
            return false;

        Splay(node);
        
        // TODO: 1) delete node, 2) concat other branches
        
        return node.Key == key;
    }

    /// <summary>
    /// Searching for a node in the tree by key
    /// </summary>
    /// <param name="key">Node key</param>
    /// <returns>Found node or closest parent or null</returns>
    private Node? TreeSearch(uint key)
    {
        if (_root == null)
            return null;
        
        var ptr = _root;
        
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
    
    private Node Splay(Node node)
    {
        throw new NotImplementedException();
    }

    private void Zig(Node node)
    {
        
    }
    
    private void Zag(Node node)
    {
        
    }
}
