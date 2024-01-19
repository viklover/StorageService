using Core.Storage.Interfaces.Updates.Types;

namespace Core.Storage.Interfaces.Updates;

/// <summary>
/// Update of storage
/// </summary>
public interface IStorageUpdate
{
    /// <summary>
    /// Get list of events about updated pairs
    /// </summary>
    /// <returns>List of tuples: pair + update type</returns>
    List<Tuple<IPair, PairUpdateType>> Pairs();
}