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
    /// <param name="sender">Notification sender</param>
    /// <param name="update">Update event entity</param>
    void OnUpdate(IStorageUpdate<uint> update);
    
    /// <summary>
    /// Save all updates in database
    /// </summary>
    /// <returns>true if changes were saved successful, otherwise - false</returns>
    bool Commit();
}