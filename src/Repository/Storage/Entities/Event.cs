namespace Repository.Storage.Entities;

public class Event
{
    public short StorageId { get; set; }
    public DateTimeOffset Time { get; set; }
    public sbyte OperationType { get; set; }
    public string Key { get; set; }
    public string? Payload { get; set; }
}