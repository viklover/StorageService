using Core.Storage.Impl.Tree.Entities.Nodes;
using Core.Storage.Impl.Tree.Entities.Trees;

namespace Core.Storage.Fixtures;

public class SplatTreeFixture 
{
    public SplayTree Tree { get; } = new();

    public Dictionary<string, Node> Nodes = new()
    {
        { "a", new Node("a", "1") },
        { "d", new Node("d", "4") },
        { "c", new Node("c", "3") },
        { "b", new Node("b", "2") },
        { "o", new Node("o", "15") },
        { "i", new Node("i", "9") },
        { "g", new Node("g", "7") },
        { "l", new Node("l", "12") },
        { "j", new Node("j", "10") },
    };
}