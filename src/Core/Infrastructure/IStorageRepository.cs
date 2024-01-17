using Core.Storage.Interfaces.Updates;

namespace Core.Infrastructure;

/// <summary>
/// Interface of storage repository
/// represents proxy to communicate with database
/// </summary>
public interface IStorageRepository<T>
{
    /// <summary>
    /// Create required keyspaces and table
    /// if they aren't exists
    /// </summary>
    void PrepareSchemas();

    /// <summary>
    /// Apply storage service update
    /// </summary>
    /// <param name="update">Update event entity</param>
    /// <returns>true if database was updated successful, otherwise - false</returns>
    bool ApplyUpdate(IStorageUpdate<T> update);
}