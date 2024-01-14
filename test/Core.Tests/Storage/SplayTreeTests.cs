using Core.Storage.Impl.SplayTree.Entities;

namespace Core.Storage;

public class SplayTreeTests
{
    [Fact]
    public void Test1()
    {
        var tree = new SplayTree();
        tree.Insert(new Node(1, "A"), out var wasUpdated);
        Assert.False(wasUpdated);
        
        tree.Insert(new Node(1, "B"), out wasUpdated);
        Assert.True(wasUpdated);
    }
}