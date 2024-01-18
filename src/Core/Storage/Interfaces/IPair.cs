namespace Core.Storage.Interfaces;

/// <summary>
/// Key-value pair - elementary unit of storage service
/// </summary>
public interface IPair
{
    string Key { get; }
    string Value { get; }
}