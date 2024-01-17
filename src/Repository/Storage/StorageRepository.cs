using Cassandra;
using Core.Infrastructure;
using Core.Storage.Interfaces.Updates;

namespace Repository.Storage;

public class StorageRepository : IStorageRepository<uint>
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

    public bool ApplyUpdate(IStorageUpdate<uint> update)
    {
        // throw new NotImplementedException();
        return false;
    }

    ~StorageRepository()
    {
        _cluster.Dispose();
    }
}