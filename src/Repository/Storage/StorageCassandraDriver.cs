using Cassandra;

namespace Repository.Storage;

public class StorageCassandraDriver
{
    private readonly Cluster _cluster = Cluster.Builder()
        .AddContactPoint(Environment.GetEnvironmentVariable("CASSANDRA_HOST"))
        .WithAuthProvider(
            new PlainTextAuthProvider(
                Environment.GetEnvironmentVariable("CASSANDRA_USER"),
                Environment.GetEnvironmentVariable("CASSANDRA_PASSWORD")))
        .Build();

    public ISession Session() => _cluster.Connect("storage");

    ~StorageCassandraDriver()
    {
        _cluster.Dispose();
    }
}