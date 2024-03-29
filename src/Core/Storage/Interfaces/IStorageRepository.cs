using Core.Storage.Interfaces.Operations;

namespace Core.Storage.Interfaces;

/// <summary>
/// Interface of storage repository
/// represents proxy to communicate with database
/// </summary>
public interface IStorageRepository
{
    /// <summary>
    /// Save operation in events store
    /// </summary>
    /// <returns>Success of processed operation</returns>
    Task<bool> CommitOperation(IOperation operation);
    
    /// <summary>
    /// Get generator for committed operations reading
    /// </summary>
    /// <returns>generator</returns>
    IEnumerator<Operation> CommittedOperationsEnumerator();
}