namespace Core.Storage.Impl.Fake;

public class FakeStorageService : IStorageService
{
    private readonly Dictionary<string, string> _data = new();
    
    public void SaveOrUpdatePair(string key, string value)
    {
        _data.Add(key, value);
    }

    public string? GetValueByKey(string key)
    {
        _data.TryGetValue(key, out var value);
        return value;
    }

    public void DeletePairByKey(string key)
    {
        _data.Remove(key);
    }
}