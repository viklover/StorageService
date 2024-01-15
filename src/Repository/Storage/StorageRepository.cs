using Cassandra;
using Core.Storage.Impl.Tree.Infrastructure;

namespace Repository.Storage;

public class StorageRepository : IStorageRepository
{
    private readonly Cluster _cluster = Cluster.Builder()
        .AddContactPoint(Environment.GetEnvironmentVariable("CASSANDRA_HOST"))
        .WithAuthProvider(
            new PlainTextAuthProvider(
                Environment.GetEnvironmentVariable("CASSANDRA_USER"),
                Environment.GetEnvironmentVariable("CASSANDRA_PASSWORD")))
        .Build();

    public ISession Session() => _cluster.Connect("storage");

    public void PrepareSchemas()
    {
        // throw new NotImplementedException();
    }

    ~StorageRepository()
    {
        _cluster.Dispose();
    }
}