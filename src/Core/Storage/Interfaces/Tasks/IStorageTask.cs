using Core.Storage.Interfaces.Operations;

namespace Core.Storage.Interfaces.Tasks;

/// <summary>
/// Task to produce operation on storage
/// </summary>
public interface IStorageTask
{
    /// <summary>
    /// Type of operation
    /// </summary>
    OperationType OperationType { get; }
    
    /// <summary>
    /// Variable name
    /// </summary>
    string Key { get; }
    
    /// <summary>
    /// Payload, that can be used for:
    ///  * 1) passing arguments to operations
    ///  * 2) responses from queue processor
    /// </summary>
    string? Payload { get; set; }

    /// <summary>
    /// Success of completed task
    /// </summary>
    bool IsSuccess { get; set; }
}