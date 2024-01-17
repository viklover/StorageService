namespace Core.Storage.Interfaces.Updates;

/// <summary>
/// Interface of storage updates service.
/// Represents a store for storage changes storing
/// </summary>
public interface IStorageUpdatesService<T>
{ 
    /// <summary>
    /// Add update to changes list, that has to be saved in
    /// repository
    /// </summary>
    /// <param name="update">Update entity</param>
    void Add(IStorageUpdate<T> update);
    
    /// <summary>
    /// Save all updates in database
    /// </summary>
    /// <returns>true if changes were saved successful, otherwise - false</returns>
    bool Commit();
}