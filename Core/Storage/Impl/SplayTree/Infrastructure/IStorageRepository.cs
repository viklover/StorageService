namespace Core.Storage.Impl.SplayTree.Infrastructure;

/// <summary>
/// Interface of storage repository
/// represents proxy to communicate with database
/// </summary>
public interface IStorageRepository
{
    /// <summary>
    /// Create required keyspaces and table
    /// if they aren't exists
    /// </summary>
    void PrepareSchemas();
}