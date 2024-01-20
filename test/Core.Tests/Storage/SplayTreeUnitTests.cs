using Core.Storage.Impl.Tree;
using Core.Storage.Impl.Tree.Nodes;
using Core.Storage.Impl.Tree.Trees;

namespace Core.Storage;

public class SplayTreeUnitTests
{
    private readonly SplayTree _tree = new();

    [Fact]
    public void RootlessTreeOperations()
    {
        Assert.Null(_tree.Search("Hello"));
        Assert.False(_tree.Delete("Hello"));
    }

    [Fact]
    public void OperationsWithFirstNode()
    {
        var a = new Node("a", "a");
        
        Assert.NotNull(_tree.Insert(a));
        Assert.True(_tree.Delete(a.Key));
    }

    [Fact]
    public void ConsistencyIsBroken()
    {
        var a = new Node("a", "a");
        var b = new Node("b", "b");
        var c = new Node("c", "c");

        _tree.Insert(a);
        _tree.Insert(b);
        _tree.Insert(c);

        a.Parent = b;
        b.Parent = a;

        Assert.Throws<Exception>(() => _tree.Search("a"));
    }

    [Fact]
    public void NodeRelations1()
    {
        var a = new Node("a", "a");
        var b = new Node("b", "b");
        
        b.Parent = a;
        a.Left = b;
        
        Assert.Equal(RelationType.LeftChild, a.CheckRelationBy(b));
    }
    
    [Fact]
    public void NodeRelations2()
    {
        var a = new Node("a", "a");
        var b = new Node("b", "b");
        
        b.Parent = a;
        a.Right = b;
        
        Assert.Equivalent(RelationType.RightChild, a.CheckRelationBy(b));
    }
    
    [Fact]
    public void NodeRelations3()
    {
        var a = new Node("a", "a");
        var b = new Node("b", "b");
        
        Assert.Equivalent(RelationType.None, a.CheckRelationBy(b));
    }
    
    [Fact]
    public void NodeRelations4()
    {
        Assert.Equivalent(RelationType.None, new Node("a", "a").CheckRelationBy(null));
    }
}