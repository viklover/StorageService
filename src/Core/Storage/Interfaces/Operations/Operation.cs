namespace Core.Storage.Interfaces.Operations;

public record Operation(OperationType OperationType, string Key, string? Payload);