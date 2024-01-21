namespace Repository.Storage.Entities;

public class Event(string key)
{
    public short StorageId { get; set; }
    public long Time { get; set; }
    public sbyte OperationType { get; set; }
    public string Key { get; set; } = key;
    public string? Payload { get; set; }
}