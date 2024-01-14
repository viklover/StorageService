using Cassandra;
using Core.Storage.Impl.SplayTree.Infrastructure;

namespace Repository.Storage;

public class StorageRepository : IStorageRepository
{
    private readonly Cluster _cluster = Cluster.Builder()
        .AddContactPoint(Environment.GetEnvironmentVariable("CLUSTER_URL"))
        .Build();

    public ISession Session() => _cluster.Connect("storage");

    public void PrepareSchemas()
    {
        throw new NotImplementedException();
    }
    
    ~StorageRepository()
    {
        _cluster.Dispose();
    }
}