namespace Application.Api.Storage.Exceptions;

public class NotFoundException(string key) : Exception($"Pair not found by key '{key}'");