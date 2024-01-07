namespace Application.Services.Storage;

public interface IStorageService
{
    void SaveOrUpdatePair(string key, string value);
    string? GetValueByKey(string key);
    void DeletePairByKey(string key);
}