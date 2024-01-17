namespace Core.Storage.Interfaces.Updates;

/// <summary>
/// Update of storage
/// </summary>
/// <typeparam name="T">
/// Represents a key type in storage service implementation
/// </typeparam>
public interface IStorageUpdate<T>
{
    /// <summary>
    /// Get list of events about pair 
    /// </summary>
    /// <returns></returns>
    List<Tuple<IPair<T>, PairUpdateType>> Pairs();
}