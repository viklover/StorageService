namespace Core.Storage.Interfaces.Updates.Types;

/// <summary>
/// StorageUpdateHandler delegate.
/// Can be used for csharp events - mechanism for receiving push-based notifications
/// </summary>
/// <typeparam name="T">Represents a key type in storage service implementation</typeparam>
public delegate void StorageUpdateHandler<T>(IStorageUpdate<T> update);