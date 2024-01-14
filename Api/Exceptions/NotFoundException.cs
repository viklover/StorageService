namespace Api.Exceptions;

public class NotFoundException(string key) : Exception($"Pair not found by key '{key}'");