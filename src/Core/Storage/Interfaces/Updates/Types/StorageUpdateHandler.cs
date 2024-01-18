namespace Core.Storage.Interfaces.Updates.Types;

/// <summary>
/// StorageUpdateHandler delegate.
/// Can be used for csharp events - mechanism for receiving push-based notifications
/// </summary>
public delegate void StorageUpdateHandler(IStorageUpdate update);