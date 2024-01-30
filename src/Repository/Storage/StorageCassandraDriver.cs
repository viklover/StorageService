using Cassandra;
using Microsoft.Extensions.Logging;

namespace Repository.Storage;

/// <summary>
/// Storage cassandra driver.
/// Represents class for giving sessions
/// </summary>
public class StorageCassandraDriver(ILogger<StorageCassandraDriver> logger) : IDisposable
{
    private readonly Cluster _cluster = Cluster.Builder()
        .AddContactPoint(Environment.GetEnvironmentVariable("CASSANDRA_HOST"))
        .WithAuthProvider(
            new PlainTextAuthProvider(
                Environment.GetEnvironmentVariable("CASSANDRA_USER"),
                Environment.GetEnvironmentVariable("CASSANDRA_PASSWORD")))
        .Build();

    private static readonly string? SchemasDirectory =
        Environment.GetEnvironmentVariable("CASSANDRA_SCHEMAS_DIRECTORY");

    /// <summary>
    /// Ask the driver for a session
    /// </summary>
    /// <returns>object implementing ISession interface</returns>
    public ISession Session() => _cluster.Connect();

    /// <summary>
    /// Create required keyspaces, tables, types, indexes
    /// if they aren't exists
    /// </summary>
    public void PrepareSchemas()
    {
        logger.LogDebug("Preparing schema in cassandra..");

        if (!Directory.Exists(SchemasDirectory))
        {
            logger.LogError("'CASSANDRA_SCHEMAS_DIRECTORY' env variable is not valid");
            return;
        }

        const string message = "  --> {SchemaName}.. {Status}";

        using var session = Session();

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

    public void Dispose()
    {
        _cluster.Dispose();

        GC.SuppressFinalize(this);
    }
}