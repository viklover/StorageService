using Cassandra;

namespace Repository.Storage;

public class StorageRepository
{
    private readonly Cluster _cluster = Cluster.Builder()
        .AddContactPoint(Environment.GetEnvironmentVariable("CLUSTER_URL"))
        .Build();

    public ISession Session() => _cluster.Connect("storage");

    ~StorageRepository()
    {
        _cluster.Dispose();
    }
}