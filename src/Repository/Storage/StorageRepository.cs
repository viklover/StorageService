using Cassandra.Mapping;
using Core.Storage.Interfaces;
using Core.Storage.Interfaces.Operations;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.CompilerServices;
using Repository.Storage.Entities;

namespace Repository.Storage;

/// <summary>
/// Repository for manipulating storage entities data
/// </summary>
/// <param name="logger">Repository logger</param>
/// <param name="driver">Storage cassandra driver</param>
public class StorageRepository(ILogger<IStorageRepository> logger, StorageCassandraDriver driver) : IStorageRepository
{
    private static readonly short StorageId =
        ShortType.FromString(Environment.GetEnvironmentVariable("SERVICE_STORAGE_ID")); // default value is 0

    /// <summary>
    /// Save operation in events store
    /// </summary>
    /// <returns>Success of processed operation</returns>
    public async Task<bool> CommitOperation(IOperation operation)
    {
        logger.LogDebug("Commiting operation: {operation}", operation);

        using var session = driver.Session();

        const string query = "INSERT INTO storages.events_by_storage " +
                             "(storage_id, time, operation_type, key, payload) VALUES " +
                             "(?, toUnixTimestamp(now()), ?, ?, ?)";
        try
        {
            var preparedStatement = await session.PrepareAsync(query);
            var statement = preparedStatement.Bind(StorageId,
                (sbyte)operation.OperationType,
                operation.Key,
                operation.Payload);

            await session.ExecuteAsync(statement);
        }
        catch (Exception exception)
        {
            logger.LogCritical("Cassandra driver exception: {exception}", exception);
            return await Task.FromResult(false);
        }

        return await Task.FromResult(true);
    }

    /// <summary>
    /// Get generator for operations reading
    /// </summary>
    /// <returns>generator</returns>
    public IEnumerator<Operation> CommittedOperationsEnumerator()
    {
        using var session = driver.Session();
        var mapper = new Mapper(session);

        var generator = mapper.Fetch<Event>("WHERE storage_id = ?", StorageId);

        foreach (var eventModel in generator)
        {
            yield return new Operation((OperationType)eventModel.OperationType, eventModel.Key, eventModel.Payload);
        }
    }
}