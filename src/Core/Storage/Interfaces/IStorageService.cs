using Core.Storage.Interfaces.Tasks;
using System.Collections.Concurrent;

namespace Core.Storage.Interfaces;

/// <summary>
/// Interface of storage service
/// represents a key-value storage
/// </summary>
public interface IStorageService
{
    /// <summary>
    /// Queue tasks to storage service
    /// </summary>
    ConcurrentQueue<IStorageTask> Tasks { get; }
    
    /// <summary>
    /// Save or update pair in storage
    /// </summary>
    /// <param name="key">Variable name</param>
    /// <param name="value">Variable value</param>
    Task SavePairAsync(string key, string value);
    
    /// <summary>
    /// Get value from storage by key
    /// </summary>
    /// <param name="key">Variable key</param>
    /// <returns>Variable value if pair was found otherwise - null</returns>
    Task<string?> GetValueByKey(string key);
    
    /// <summary>
    /// Delete in storage pair by key
    /// </summary>
    /// <param name="key">Variable key</param>
    Task DeletePairByKeyAsync(string key);
}