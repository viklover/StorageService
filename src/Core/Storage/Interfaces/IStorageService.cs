namespace Core.Storage.Interfaces;

/// <summary>
/// Interface of storage service
/// represents a key-value storage
/// </summary>
public interface IStorageService
{
    /// <summary>
    /// Save or update pair in storage
    /// </summary>
    /// <param name="key">Variable name</param>
    /// <param name="value">Variable value</param>
    void SaveOrUpdatePair(string key, string value);
    
    /// <summary>
    /// Get value from storage by key
    /// </summary>
    /// <param name="key">Variable key</param>
    /// <returns>Variable value if pair was found otherwise - null</returns>
    string? GetValueByKey(string key);
    
    /// <summary>
    /// Delete in storage pair by key
    /// </summary>
    /// <param name="key">Variable key</param>
    /// <returns>true if pair was found and removed successfully, otherwise - false</returns>
    bool DeletePairByKey(string key);
}