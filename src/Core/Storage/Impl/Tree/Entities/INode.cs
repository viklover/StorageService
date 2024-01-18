using Core.Storage.Interfaces;

namespace Core.Storage.Impl.Tree.Entities;

/// <summary>
/// Interface of tree node.
/// It's pair in storage service area.
/// </summary>
public interface INode : IPair, IComparable<INode>
{
    INode? Parent { get; set; }
    INode? Left { get; set; }
    INode? Right { get; set; }

    string Key { get; }
    string Value { get; set; }
}