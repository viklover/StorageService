using Core.Storage.Interfaces.Updates;

namespace Core.Storage.Interfaces;

/// <summary>
/// Interface of storage repository
/// represents proxy to communicate with database
/// </summary>
public interface IStorageRepository
{
    /// <summary>
    /// Create required keyspaces, tables, types, indexes
    /// if they aren't exists
    /// </summary>
    void PrepareSchemas();

    /// <summary>
    /// Apply storage service update
    /// </summary>
    /// <param name="update">Update event entity</param>
    /// <returns>true if database was updated successful, otherwise - false</returns>
    bool ApplyUpdate(IStorageUpdate update);
}