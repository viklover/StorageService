using Core.Storage.Impl.Tree.Entities;

namespace Core.Storage;

public class SplayTreeInsertionTests
{
    private readonly SplayTree _tree = new SplayTree();
    
    [Fact]
    public void InsertionTests()
    {
        var a = new Node(1, "1");
        var b = new Node(4, "4");
        var c = new Node(3, "3");
        var d = new Node(2, "2");
        var e = new Node(15, "15");
        var f = new Node(7, "7");
        
        _tree.Insert(a);
        Assert.Null(a.Parent);
        Assert.Same(a, _tree.root);
        
        _tree.Insert(b);
        Assert.Null(b.Parent);
        Assert.Same(b, _tree.root);
        Assert.Same(a, _tree.root?.Left);
        // parents check
        Assert.Same(b, _tree.root?.Left?.Parent);
        
        _tree.Insert(c);
        Assert.Null(c.Parent);
        Assert.Same(c, _tree.root);
        Assert.Same(a, _tree.root?.Left);
        Assert.Same(b, _tree.root?.Right);
        // parents check
        Assert.Same(c, _tree.root?.Left?.Parent); 
        Assert.Same(c, _tree.root?.Right?.Parent);
        
        _tree.Insert(d);
        Assert.Null(d.Parent);
        Assert.Same(d, _tree.root);
        Assert.Same(a, _tree.root?.Left);
        Assert.Same(c, _tree.root?.Right);
        Assert.Same(b, _tree.root?.Right?.Right);
        // parents check
        Assert.Same(d, _tree.root?.Left?.Parent);
        Assert.Same(d, _tree.root?.Right?.Parent);
        Assert.Same(c, _tree.root?.Right?.Right?.Parent);

        _tree.Insert(e);
        Assert.Null(e.Parent);
        Assert.Same(e, _tree.root);
        Assert.Same(b, _tree.root?.Left);
        Assert.Same(c, _tree.root?.Left?.Left);
        Assert.Same(d, _tree.root?.Left?.Left?.Left);
        Assert.Same(a, _tree.root?.Left?.Left?.Left?.Left);
        // parents check
        Assert.Same(e, _tree.root?.Left?.Parent);
        Assert.Same(b, _tree.root?.Left?.Left?.Parent);
        Assert.Same(c, _tree.root?.Left?.Left?.Left?.Parent);
        Assert.Same(d, _tree.root?.Left?.Left?.Left?.Left?.Parent);


        // Assert.False(wasUpdated);
        //
        // Tree.Insert(new Node(1, "B"), out wasUpdated);
        // Assert.True(wasUpdated);
    }
}