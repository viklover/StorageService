using Core.Storage.Fixtures;
using Core.Storage.Impl.Tree.Nodes;
using Core.Storage.Impl.Tree.Trees;
using Tests.Configurations.Priority;

namespace Core.Storage;

/// <summary>
/// Unit tests based on using splay tree
/// (that's like big integration test)
/// </summary>
/// <param name="fixture"></param>
[TestCaseOrderer("Tests.Configurations.Priority.PriorityOrderer", "Tests.Configurations")]
public class SplayTreeUsageTests(SplatTreeFixture fixture) : IClassFixture<SplatTreeFixture>
{
    private readonly SplayTree _tree = fixture.Tree;
    private readonly Dictionary<string, Node> nodes = fixture.Nodes;

    [Fact, TestPriority(0)]
    public void FillTree()
    {
        _tree.Insert(nodes["a"]);
        Assert.Null(nodes["a"].Parent);
        Assert.Same(nodes["a"], _tree.Root);
        // predecessors check
        Assert.Null(nodes["a"].Left);
        Assert.Null(nodes["a"].Right);

        _tree.Insert(nodes["d"]);
        Assert.Null(nodes["d"].Parent);
        Assert.Same(nodes["d"], _tree.Root);
        Assert.Same(nodes["a"], nodes["d"].Left);
        // predecessors and parents check
        Assert.Same(nodes["d"], nodes["a"].Parent);
        Assert.Null(nodes["d"].Right);
        Assert.Null(nodes["a"].Left);
        Assert.Null(nodes["a"].Right);

        _tree.Insert(nodes["c"]);
        Assert.Null(nodes["c"].Parent);
        Assert.Same(nodes["c"], _tree.Root);
        Assert.Same(nodes["a"], nodes["c"].Left);
        Assert.Same(nodes["d"], nodes["c"].Right);
        // predecessors and parents check
        Assert.Same(nodes["c"], nodes["a"].Parent);
        Assert.Same(nodes["c"], nodes["d"].Parent);
        Assert.Null(nodes["a"].Left);
        Assert.Null(nodes["a"].Right);
        Assert.Null(nodes["d"].Left);
        Assert.Null(nodes["d"].Right);

        _tree.Insert(nodes["b"]);
        Assert.Null(nodes["b"].Parent);
        Assert.Same(nodes["b"], _tree.Root);
        Assert.Same(nodes["a"], nodes["b"].Left);
        Assert.Same(nodes["c"], nodes["b"].Right);
        Assert.Same(nodes["d"], nodes["c"].Right);
        // predecessors and parents check
        Assert.Same(nodes["b"], nodes["a"].Parent);
        Assert.Same(nodes["b"], nodes["c"].Parent);
        Assert.Same(nodes["c"], nodes["d"].Parent);
        Assert.Null(nodes["a"].Left);
        Assert.Null(nodes["a"].Right);
        Assert.Null(nodes["c"].Left);
        Assert.Null(nodes["d"].Left);
        Assert.Null(nodes["d"].Right);

        _tree.Insert(nodes["o"]);
        Assert.Null(nodes["o"].Parent);
        Assert.Same(nodes["o"], _tree.Root);
        Assert.Same(nodes["d"], nodes["o"].Left);
        Assert.Same(nodes["c"], nodes["d"].Left);
        Assert.Same(nodes["b"], nodes["c"].Left);
        Assert.Same(nodes["a"], nodes["b"].Left);
        // predecessors and parents check
        Assert.Same(nodes["o"], nodes["d"].Parent);
        Assert.Same(nodes["d"], nodes["c"].Parent);
        Assert.Same(nodes["c"], nodes["b"].Parent);
        Assert.Same(nodes["b"], nodes["a"].Parent);
        Assert.Null(nodes["a"].Left);
        Assert.Null(nodes["a"].Right);
        Assert.Null(nodes["b"].Right);
        Assert.Null(nodes["c"].Right);
        Assert.Null(nodes["d"].Right);
        Assert.Null(nodes["o"].Right);

        _tree.Insert(nodes["i"]);
        Assert.Null(nodes["i"].Parent);
        Assert.Same(nodes["i"], _tree.Root);
        Assert.Same(nodes["o"], nodes["i"].Right);
        Assert.Same(nodes["d"], nodes["i"].Left);
        Assert.Same(nodes["c"], nodes["d"].Left);
        Assert.Same(nodes["b"], nodes["c"].Left);
        Assert.Same(nodes["a"], nodes["b"].Left);
        // predecessors and parents check
        Assert.Same(nodes["i"], nodes["d"].Parent);
        Assert.Same(nodes["i"], nodes["o"].Parent);
        Assert.Same(nodes["d"], nodes["c"].Parent);
        Assert.Same(nodes["c"], nodes["b"].Parent);
        Assert.Same(nodes["b"], nodes["a"].Parent);
        Assert.Null(nodes["a"].Left);
        Assert.Null(nodes["a"].Right);
        Assert.Null(nodes["b"].Right);
        Assert.Null(nodes["c"].Right);
        Assert.Null(nodes["d"].Right);
        Assert.Null(nodes["o"].Left);
        Assert.Null(nodes["o"].Right);

        _tree.Insert(nodes["g"]);
        Assert.Null(nodes["g"].Parent);
        Assert.Same(nodes["g"], _tree.Root);
        Assert.Same(nodes["i"], nodes["g"].Right);
        Assert.Same(nodes["o"], nodes["i"].Right);
        Assert.Same(nodes["o"], nodes["i"].Right);
        Assert.Same(nodes["d"], nodes["g"].Left);
        Assert.Same(nodes["c"], nodes["d"].Left);
        Assert.Same(nodes["b"], nodes["c"].Left);
        Assert.Same(nodes["a"], nodes["b"].Left);
        // predecessors and parents check
        Assert.Same(nodes["g"], nodes["i"].Parent);
        Assert.Same(nodes["i"], nodes["o"].Parent);
        Assert.Same(nodes["g"], nodes["d"].Parent);
        Assert.Same(nodes["d"], nodes["c"].Parent);
        Assert.Same(nodes["c"], nodes["b"].Parent);
        Assert.Same(nodes["b"], nodes["a"].Parent);
        Assert.Null(nodes["a"].Left);
        Assert.Null(nodes["a"].Right);
        Assert.Null(nodes["b"].Right);
        Assert.Null(nodes["c"].Right);
        Assert.Null(nodes["d"].Right);
        Assert.Null(nodes["i"].Left);
        Assert.Null(nodes["o"].Left);
        Assert.Null(nodes["o"].Right);

        _tree.Insert(nodes["l"]);
        Assert.Null(nodes["l"].Parent);
        Assert.Same(nodes["o"], nodes["l"].Right);
        Assert.Same(nodes["i"], nodes["l"].Left);
        Assert.Same(nodes["g"], nodes["i"].Left);
        Assert.Same(nodes["d"], nodes["g"].Left);
        Assert.Same(nodes["c"], nodes["d"].Left);
        Assert.Same(nodes["b"], nodes["c"].Left);
        Assert.Same(nodes["a"], nodes["b"].Left);
        // predecessors and parents check
        Assert.Same(nodes["l"], nodes["o"].Parent);
        Assert.Same(nodes["l"], nodes["i"].Parent);
        Assert.Same(nodes["i"], nodes["g"].Parent);
        Assert.Same(nodes["g"], nodes["d"].Parent);
        Assert.Same(nodes["d"], nodes["c"].Parent);
        Assert.Same(nodes["c"], nodes["b"].Parent);
        Assert.Same(nodes["b"], nodes["a"].Parent);
        Assert.Null(nodes["a"].Left);
        Assert.Null(nodes["a"].Right);
        Assert.Null(nodes["b"].Right);
        Assert.Null(nodes["c"].Right);
        Assert.Null(nodes["d"].Right);
        Assert.Null(nodes["g"].Right);
        Assert.Null(nodes["i"].Right);
        Assert.Null(nodes["o"].Left);
        Assert.Null(nodes["o"].Right);

        _tree.Insert(nodes["j"]);
        Assert.Null(nodes["j"].Parent);
        Assert.Same(nodes["i"], nodes["j"].Left);
        Assert.Same(nodes["l"], nodes["j"].Right);
        Assert.Same(nodes["o"], nodes["l"].Right);
        Assert.Same(nodes["g"], nodes["i"].Left);
        Assert.Same(nodes["d"], nodes["g"].Left);
        Assert.Same(nodes["c"], nodes["d"].Left);
        Assert.Same(nodes["b"], nodes["c"].Left);
        Assert.Same(nodes["a"], nodes["b"].Left);
        // predecessors and parents check
        Assert.Same(nodes["j"], nodes["i"].Parent);
        Assert.Same(nodes["j"], nodes["l"].Parent);
        Assert.Same(nodes["l"], nodes["o"].Parent);
        Assert.Same(nodes["i"], nodes["g"].Parent);
        Assert.Same(nodes["g"], nodes["d"].Parent);
        Assert.Same(nodes["d"], nodes["c"].Parent);
        Assert.Same(nodes["c"], nodes["b"].Parent);
        Assert.Same(nodes["b"], nodes["a"].Parent);
        Assert.Null(nodes["a"].Left);
        Assert.Null(nodes["a"].Right);
        Assert.Null(nodes["b"].Right);
        Assert.Null(nodes["c"].Right);
        Assert.Null(nodes["d"].Right);
        Assert.Null(nodes["g"].Right);
        Assert.Null(nodes["i"].Right);
        Assert.Null(nodes["l"].Left);
        Assert.Null(nodes["o"].Left);
        Assert.Null(nodes["o"].Right);
    }

    [Fact, TestPriority(1)]
    public void MixingNodes()
    {
        var l = _tree.Search("l");
        Assert.NotNull(l);
        Assert.Same(_tree.Root, l);
        Assert.Same(nodes["l"], l);
        Assert.Null(nodes["l"].Parent);
        Assert.Same(nodes["o"], nodes["l"].Right);
        Assert.Same(nodes["j"], nodes["l"].Left);
        Assert.Same(nodes["i"], nodes["j"].Left);
        Assert.Same(nodes["g"], nodes["i"].Left);
        Assert.Same(nodes["d"], nodes["g"].Left);
        Assert.Same(nodes["c"], nodes["d"].Left);
        Assert.Same(nodes["b"], nodes["c"].Left);
        Assert.Same(nodes["a"], nodes["b"].Left);
        // predecessors and parents check
        Assert.Same(nodes["l"], nodes["j"].Parent);
        Assert.Same(nodes["l"], nodes["o"].Parent);
        Assert.Same(nodes["j"], nodes["i"].Parent);
        Assert.Same(nodes["i"], nodes["g"].Parent);
        Assert.Same(nodes["g"], nodes["d"].Parent);
        Assert.Same(nodes["d"], nodes["c"].Parent);
        Assert.Same(nodes["c"], nodes["b"].Parent);
        Assert.Same(nodes["b"], nodes["a"].Parent);
        Assert.Null(nodes["a"].Left);
        Assert.Null(nodes["a"].Right);
        Assert.Null(nodes["b"].Right);
        Assert.Null(nodes["c"].Right);
        Assert.Null(nodes["d"].Right);
        Assert.Null(nodes["g"].Right);
        Assert.Null(nodes["i"].Right);
        Assert.Null(nodes["j"].Right);
        Assert.Null(nodes["o"].Left);
        Assert.Null(nodes["o"].Right);

        var c = _tree.Search("c");
        Assert.NotNull(c);
        Assert.Null(c.Parent);
        Assert.Same(_tree.Root, c);
        Assert.Same(nodes["c"], c);
        Assert.Same(nodes["b"], nodes["c"].Left);
        Assert.Same(nodes["l"], nodes["c"].Right);
        Assert.Same(nodes["a"], nodes["b"].Left);
        Assert.Same(nodes["o"], nodes["l"].Right);
        Assert.Same(nodes["i"], nodes["l"].Left);
        Assert.Same(nodes["d"], nodes["i"].Left);
        Assert.Same(nodes["j"], nodes["i"].Right);
        Assert.Same(nodes["g"], nodes["d"].Right);
        // predecessors and parents check
        Assert.Same(nodes["c"], nodes["b"].Parent);
        Assert.Same(nodes["c"], nodes["l"].Parent);
        Assert.Same(nodes["b"], nodes["a"].Parent);
        Assert.Same(nodes["l"], nodes["i"].Parent);
        Assert.Same(nodes["l"], nodes["o"].Parent);
        Assert.Same(nodes["i"], nodes["d"].Parent);
        Assert.Same(nodes["i"], nodes["j"].Parent);
        Assert.Same(nodes["d"], nodes["g"].Parent);
        Assert.Null(nodes["a"].Left);
        Assert.Null(nodes["a"].Right);
        Assert.Null(nodes["b"].Right);
        Assert.Null(nodes["d"].Left);
        Assert.Null(nodes["g"].Left);
        Assert.Null(nodes["g"].Right);
        Assert.Null(nodes["j"].Left);
        Assert.Null(nodes["j"].Right);
        Assert.Null(nodes["o"].Left);
        Assert.Null(nodes["o"].Right);

        var g = _tree.Insert(SplayTree.CreateNode("g", "gg"));
        Assert.Null(g.Parent);
        Assert.Same(g, _tree.Root);
        Assert.Same(nodes["g"], g);
        Assert.Same(nodes["c"], g.Left);
        Assert.Same(nodes["l"], g.Right);
        Assert.Same(nodes["d"], nodes["c"].Right);
        Assert.Same(nodes["b"], nodes["c"].Left);
        Assert.Same(nodes["a"], nodes["b"].Left);
        Assert.Same(nodes["o"], nodes["l"].Right);
        Assert.Same(nodes["j"], nodes["i"].Right);
        // predecessors and parents check
        Assert.Same(nodes["g"], nodes["c"].Parent);
        Assert.Same(nodes["g"], nodes["l"].Parent);
        Assert.Same(nodes["c"], nodes["b"].Parent);
        Assert.Same(nodes["c"], nodes["d"].Parent);
        Assert.Same(nodes["b"], nodes["a"].Parent);
        Assert.Same(nodes["l"], nodes["i"].Parent);
        Assert.Same(nodes["i"], nodes["j"].Parent);
        Assert.Null(nodes["a"].Left);
        Assert.Null(nodes["a"].Right);
        Assert.Null(nodes["b"].Right);
        Assert.Null(nodes["d"].Left);
        Assert.Null(nodes["d"].Right);
        Assert.Null(nodes["i"].Left);
        Assert.Null(nodes["j"].Left);
        Assert.Null(nodes["j"].Right);
        Assert.Null(nodes["o"].Left);
        Assert.Null(nodes["o"].Right);
    }

    [Fact, TestPriority(2)]
    public void Deletions()
    {
        var result = _tree.Delete("g");
        Assert.True(result);
        
        Assert.Same(nodes["i"], _tree.Root);
        Assert.Same(nodes["c"], nodes["i"].Left);
        Assert.Same(nodes["l"], nodes["i"].Right);
        Assert.Same(nodes["o"], nodes["l"].Right);
        Assert.Same(nodes["j"], nodes["l"].Left);
        Assert.Same(nodes["d"], nodes["c"].Right);
        Assert.Same(nodes["b"], nodes["c"].Left);
        Assert.Same(nodes["a"], nodes["b"].Left);
        // predecessors and parents check
        Assert.Same(nodes["i"], nodes["c"].Parent);
        Assert.Same(nodes["i"], nodes["l"].Parent);
        Assert.Same(nodes["l"], nodes["j"].Parent);
        Assert.Same(nodes["l"], nodes["o"].Parent);
        Assert.Same(nodes["c"], nodes["b"].Parent);
        Assert.Same(nodes["c"], nodes["d"].Parent);
        Assert.Same(nodes["b"], nodes["a"].Parent);
        Assert.Null(nodes["a"].Left);
        Assert.Null(nodes["a"].Right);
        Assert.Null(nodes["b"].Right);
        Assert.Null(nodes["d"].Left);
        Assert.Null(nodes["d"].Right);
        Assert.Null(nodes["j"].Left);
        Assert.Null(nodes["j"].Right);
        Assert.Null(nodes["o"].Left);
        Assert.Null(nodes["o"].Right);

        var a = _tree.Search("a");
        Assert.NotNull(a);
        Assert.Null(a.Parent);
        Assert.Same(a, _tree.Root);
        Assert.Same(nodes["a"], a);
        Assert.Same(nodes["i"], a.Right);
        Assert.Same(nodes["b"], nodes["i"].Left);
        Assert.Same(nodes["c"], nodes["b"].Right);
        Assert.Same(nodes["d"], nodes["c"].Right);
        Assert.Same(nodes["l"], nodes["i"].Right);
        Assert.Same(nodes["o"], nodes["l"].Right);
        Assert.Same(nodes["j"], nodes["l"].Left);
        // predecessors and parents check
        Assert.Same(nodes["a"], nodes["i"].Parent);
        Assert.Same(nodes["i"], nodes["b"].Parent);
        Assert.Same(nodes["i"], nodes["l"].Parent);
        Assert.Same(nodes["l"], nodes["j"].Parent);
        Assert.Same(nodes["l"], nodes["o"].Parent);
        Assert.Same(nodes["b"], nodes["c"].Parent);
        Assert.Same(nodes["c"], nodes["d"].Parent);
        Assert.Null(nodes["a"].Left);
        Assert.Null(nodes["b"].Left);
        Assert.Null(nodes["c"].Left);
        Assert.Null(nodes["d"].Left);
        Assert.Null(nodes["d"].Right);
        Assert.Null(nodes["j"].Left);
        Assert.Null(nodes["j"].Right);
        Assert.Null(nodes["o"].Left);
        Assert.Null(nodes["o"].Right);
        
        var j = _tree.Search("j");
        Assert.NotNull(j);
        Assert.Null(j.Parent);
        Assert.Same(j, _tree.Root);
        Assert.Same(nodes["j"], j);
        Assert.Same(nodes["a"], j.Left);
        Assert.Same(nodes["l"], j.Right);
        Assert.Same(nodes["o"], nodes["l"].Right);
        Assert.Same(nodes["i"], nodes["a"].Right);
        Assert.Same(nodes["b"], nodes["i"].Left);
        Assert.Same(nodes["c"], nodes["b"].Right);
        Assert.Same(nodes["d"], nodes["c"].Right);
        // predecessors and parents check
        Assert.Same(nodes["j"], nodes["a"].Parent);
        Assert.Same(nodes["j"], nodes["l"].Parent);
        Assert.Same(nodes["l"], nodes["o"].Parent);
        Assert.Same(nodes["a"], nodes["i"].Parent);
        Assert.Same(nodes["i"], nodes["b"].Parent);
        Assert.Same(nodes["b"], nodes["c"].Parent);
        Assert.Same(nodes["c"], nodes["d"].Parent);
        Assert.Null(nodes["a"].Left);
        Assert.Null(nodes["i"].Right);
        Assert.Null(nodes["b"].Left);
        Assert.Null(nodes["c"].Left);
        Assert.Null(nodes["d"].Left);
        Assert.Null(nodes["d"].Right);
        Assert.Null(nodes["l"].Left);
        Assert.Null(nodes["o"].Left);
        Assert.Null(nodes["o"].Right);
        
        Assert.True(_tree.Delete("b"));
        Assert.Same(nodes["c"], _tree.Root);
        Assert.Same(nodes["a"], nodes["c"].Left);
        Assert.Same(nodes["i"], nodes["c"].Right);
        Assert.Same(nodes["d"], nodes["i"].Left);
        Assert.Same(nodes["j"], nodes["i"].Right);
        Assert.Same(nodes["l"], nodes["j"].Right);
        Assert.Same(nodes["o"], nodes["l"].Right);
        // predecessors and parents check
        Assert.Same(nodes["c"], nodes["a"].Parent);
        Assert.Same(nodes["c"], nodes["i"].Parent);
        Assert.Same(nodes["i"], nodes["d"].Parent);
        Assert.Same(nodes["i"], nodes["j"].Parent);
        Assert.Same(nodes["j"], nodes["l"].Parent);
        Assert.Same(nodes["l"], nodes["o"].Parent);
        Assert.Null(nodes["a"].Left);
        Assert.Null(nodes["a"].Right);
        Assert.Null(nodes["d"].Left);
        Assert.Null(nodes["d"].Right);
        Assert.Null(nodes["j"].Left);
        Assert.Null(nodes["l"].Left);
        Assert.Null(nodes["o"].Left);
        Assert.Null(nodes["o"].Right);
        
        Assert.True(_tree.Delete("a"));
        Assert.Same(nodes["c"], _tree.Root);
        Assert.Same(nodes["i"], nodes["c"].Right);
        Assert.Same(nodes["d"], nodes["i"].Left);
        Assert.Same(nodes["j"], nodes["i"].Right);
        Assert.Same(nodes["l"], nodes["j"].Right);
        Assert.Same(nodes["o"], nodes["l"].Right);
        // predecessors and parents check
        Assert.Same(nodes["c"], nodes["i"].Parent);
        Assert.Same(nodes["i"], nodes["d"].Parent);
        Assert.Same(nodes["i"], nodes["j"].Parent);
        Assert.Same(nodes["j"], nodes["l"].Parent);
        Assert.Same(nodes["l"], nodes["o"].Parent);
        Assert.Null(nodes["d"].Left);
        Assert.Null(nodes["d"].Right);
        Assert.Null(nodes["j"].Left);
        Assert.Null(nodes["l"].Left);
        Assert.Null(nodes["o"].Left);
        Assert.Null(nodes["o"].Right);
        
        Assert.True(_tree.Delete("o"));
        Assert.Same(nodes["i"], _tree.Root);
        Assert.Same(nodes["c"], nodes["i"].Left);
        Assert.Same(nodes["d"], nodes["c"].Right);
        Assert.Same(nodes["j"], nodes["l"].Left);
        // predecessors and parents check
        Assert.Same(nodes["i"], nodes["c"].Parent);
        Assert.Same(nodes["i"], nodes["l"].Parent);
        Assert.Same(nodes["c"], nodes["d"].Parent);
        Assert.Same(nodes["l"], nodes["j"].Parent);
        Assert.Null(nodes["c"].Left);
        Assert.Null(nodes["d"].Left);
        Assert.Null(nodes["d"].Right);
        Assert.Null(nodes["l"].Right);
        Assert.Null(nodes["j"].Left);
        Assert.Null(nodes["j"].Right);
    }
}
// получились не юнит тесты, а большой интеграционный тест структуры данных
// ну ладно
