using Core.Storage.Interfaces;

namespace Core.Storage.Impl.Tree.Entities;

/// <summary>
/// Interface of splay tree node.
/// It's pair in storage service area.
/// </summary>
public interface INode : IPair<uint>
{
    INode? Parent { get; set; }
    INode? Left { get; set; }
    INode? Right { get; set; }

    uint Key { get; }
    string Value { get; set; }
}