using Core.Storage.Interfaces.Operations;
using Core.Storage.Interfaces.Tasks;

namespace Core.Storage.Impl.Tasks;

public class StorageTask(OperationType operationType, string key, string? payload = null) : IStorageTask
{
    public OperationType OperationType { get; } = operationType;
    public string Key { get; } = key;
    public string? Payload { get; set; } = payload;
    public bool IsSuccess { get; set; }

    public override string ToString()
    {
        return $"Task(operation={OperationType.ToString()}, key={Key})";
    }
}