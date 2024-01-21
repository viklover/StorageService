namespace Core.Storage.Interfaces.Operations;

/// <summary>
/// Interface of operation object
/// </summary>
public interface IOperation
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
    string? Payload { get; }
}