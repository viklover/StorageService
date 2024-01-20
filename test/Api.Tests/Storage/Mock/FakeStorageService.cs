using System.Collections.Concurrent;

using Core.Storage.Interfaces;
using Core.Storage.Interfaces.Tasks;

namespace Api.Storage.Mock;

public class FakeStorageService : IStorageService
{
    private readonly Dictionary<string, string> _data = new();

    public ConcurrentQueue<IStorageTask> Tasks { get; } = new();
    
    public Task SavePairAsync(string key, string value)
    {
        throw new NotImplementedException();
    }

    public Task<string?> GetValueByKey(string key)
    {
        throw new NotImplementedException();
    }

    public Task DeletePairByKeyAsync(string key)
    {
        throw new NotImplementedException();
    }
}