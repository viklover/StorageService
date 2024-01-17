namespace Core.Storage.Interfaces;

/// <summary>
/// Key-value pair - elementary unit of storage service
/// </summary>
/// <typeparam name="T">
/// Represents a key type in storage service implementation
/// </typeparam>
public interface IPair<out T>
{
    T Key { get; }
    string Value { get; }
}