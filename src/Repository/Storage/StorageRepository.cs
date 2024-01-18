using Core.Infrastructure;
using Core.Storage.Interfaces.Updates;

using Cassandra;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Repository.Storage;

public class StorageRepository(ILogger<StorageRepository> logger, StorageCassandraDriver driver)
    : IStorageRepository<uint>
{
    private static readonly string? SchemasDirectory =
        Environment.GetEnvironmentVariable("CASSANDRA_SCHEMAS_DIRECTORY");

    public void PrepareSchemas()
    {
        Console.WriteLine(logger.IsEnabled(LogLevel.Debug));
        logger.LogDebug("Preparing schema in cassandra..");

        if (!Directory.Exists(SchemasDirectory))
        {
            logger.LogError("'CASSANDRA_SCHEMAS_DIRECTORY' env variable is not exists");
            return;
        }

        using var session = driver.Session();

        foreach (var file in Directory.GetFiles(SchemasDirectory).OrderBy(f => f))
        {
            var logMsg = new StringBuilder($"  --> {Path.GetFileName(file)}.. ");

            try
            {
                session.Execute(File.ReadAllText(file));

                logMsg.Append("ok");
                logger.LogDebug(logMsg.ToString());
            }
            catch (QueryExecutionException exception)
            {
                logMsg.Append("fail");
                logger.LogError(logMsg.ToString());
                throw new Exception("Applying schema error");
            }
        }
    }

    public bool ApplyUpdate(IStorageUpdate<uint> update)
    {
        // throw new NotImplementedException();
        return false;
    }
}