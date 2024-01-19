using Core.Storage.Impl.Tree.Entities;
using Core.Storage.Impl.Tree.Entities.Nodes;
using Core.Storage.Impl.Tree.Entities.Trees;

namespace Core.Storage;

public class SplayTreeInsertionTests
{
    private readonly IBinaryTree _tree = new SplayTree();
    
    [Fact]
    public void InsertionTests()
    {
        var a = new Node("a", "1");
        var d = new Node("d", "4");
        var c = new Node("c", "3");
        var b = new Node("b", "2");
        var o = new Node("o", "15");
        
        _tree.Insert(a);
        Assert.Null(a.Parent);
        Assert.Same(a, _tree.Root);
        
        _tree.Insert(d); //d
        Assert.Null(d.Parent); //d
        Assert.Same(d, _tree.Root); //d
        Assert.Same(a, _tree.Root?.Left);
        // parents check
        Assert.Same(d, _tree.Root?.Left?.Parent); //d
        
        _tree.Insert(c);
        Assert.Null(c.Parent);
        Assert.Same(c, _tree.Root);
        Assert.Same(a, _tree.Root?.Left);
        Assert.Same(d, _tree.Root?.Right); //d
        // parents check
        Assert.Same(c, _tree.Root?.Left?.Parent); 
        Assert.Same(c, _tree.Root?.Right?.Parent);
        
        _tree.Insert(b);
        Assert.Null(b.Parent);
        Assert.Same(b, _tree.Root);
        Assert.Same(a, _tree.Root?.Left);
        Assert.Same(c, _tree.Root?.Right);
        Assert.Same(d, _tree.Root?.Right?.Right); //d
        // parents check
        Assert.Same(b, _tree.Root?.Left?.Parent);
        Assert.Same(b, _tree.Root?.Right?.Parent);
        Assert.Same(c, _tree.Root?.Right?.Right?.Parent);
        
        _tree.Insert(o);
        Assert.Null(o.Parent);
        Assert.Same(o, _tree.Root);
        Assert.Same(d, _tree.Root?.Left); //d
        Assert.Same(c, _tree.Root?.Left?.Left);
        Assert.Same(b, _tree.Root?.Left?.Left?.Left);
        Assert.Same(a, _tree.Root?.Left?.Left?.Left?.Left);
        // parents check
        Assert.Same(o, _tree.Root?.Left?.Parent);
        Assert.Same(d, _tree.Root?.Left?.Left?.Parent); //d
        Assert.Same(c, _tree.Root?.Left?.Left?.Left?.Parent);
        Assert.Same(b, _tree.Root?.Left?.Left?.Left?.Left?.Parent);


        // Assert.False(wasUpdated);
        //
        // Tree.Insert(new Node(1, "B"), out wasUpdated);
        // Assert.True(wasUpdated);
    }
}