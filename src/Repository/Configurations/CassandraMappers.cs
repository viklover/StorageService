using Cassandra.Mapping;
using Repository.Storage.Entities;

namespace Repository.Configurations;

public class CassandraMappers : Mappings
{
    public CassandraMappers()
    {
        For<Event>()
            .TableName("storages.events_by_storage")
            .PartitionKey(model => model.StorageId)
            .ClusteringKey(model => model.Time)
            .Column(model => model.Time, cfg => cfg.WithName("time"))
            .Column(model => model.StorageId, cfg => cfg.WithName("storage_id"))
            .Column(model => model.OperationType, cfg => cfg.WithName("operation_type"))
            .Column(model => model.Key, cfg => cfg.WithName("key"))
            .Column(model => model.Payload, cfg => cfg.WithName("payload"));
    }
}