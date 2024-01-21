using Cassandra;
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
public class StorageRepository(ILogger<StorageRepository> logger, StorageCassandraDriver driver)
    : IStorageRepository
{
    private static readonly string? SchemasDirectory =
        Environment.GetEnvironmentVariable("CASSANDRA_SCHEMAS_DIRECTORY");

    private static readonly string? StorageId =
        Environment.GetEnvironmentVariable("SERVICE_STORAGE_ID");

    /// <summary>
    /// Create required keyspaces, tables, types, indexes
    /// if they aren't exists
    /// </summary>
    public void PrepareSchemas()
    {
        logger.LogDebug("Preparing schema in cassandra..");

        if (!Directory.Exists(SchemasDirectory))
        {
            logger.LogError("'CASSANDRA_SCHEMAS_DIRECTORY' env variable is not exists");
            return;
        }

        const string message = "  --> {SchemaName}.. {Status}";

        using var session = driver.Session();

        foreach (var file in Directory.GetFiles(SchemasDirectory).OrderBy(f => f))
        {
            var fileName = Path.GetFileName(file);

            try
            {
                session.Execute(File.ReadAllText(file));

                logger.LogDebug(message, fileName, "ok");
            }
            catch (QueryExecutionException exception)
            {
                logger.LogError(message, fileName, "not ok");
                throw new Exception($"Applying schema error {exception}");
            }
        }
    }

    /// <summary>
    /// Get generator for operations reading
    /// </summary>
    /// <returns>generator</returns>
    public IEnumerator<Operation> CommittedOperationsEnumerator()
    {
        using var session = driver.Session();
        var mapper = new Mapper(session);

        var generator = mapper.Fetch<Event>("SELECT * FROM storages.events_by_storage WHERE storage_id = ?");

        foreach (var eventModel in generator)
        {
            yield return new Operation((OperationType)eventModel.OperationType, eventModel.Key, eventModel.Payload);
        }
    }

    public async Task<bool> CommitOperation(Operation operation)
    {
        logger.LogDebug("Commiting operation: {operation}", operation);

        using var session = driver.Session();

        const string query = "INSERT INTO storages.events_by_storage " +
                             "(storage_id, time, operation_type, key, payload) VALUES " +
                             "(?, toUnixTimestamp(now()), ?, ?, ?)";
        try
        {
            var preparedStatement = await session.PrepareAsync(query);
            var statement = preparedStatement.Bind(ShortType.FromString(StorageId),
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
}