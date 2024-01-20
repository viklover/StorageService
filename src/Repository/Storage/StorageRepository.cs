using Core.Storage.Interfaces;
using Cassandra;
using Core.Storage.Interfaces.Operations;
using Microsoft.Extensions.Logging;

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

    public IEnumerator<string> GetEventsEnumerator()
    {
        throw new NotImplementedException();
    }

    public bool CommitOperation(OperationType operationType, string key, string? payload)
    {
        throw new NotImplementedException();
    }
}