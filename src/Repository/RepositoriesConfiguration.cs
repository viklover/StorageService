using Cassandra.Mapping;
using Repository.Configurations;

using Microsoft.Extensions.DependencyInjection;

namespace Repository;

using Storage;

public static class RepositoriesConfiguration
{
    public static IServiceProvider PrepareRepositories(this IServiceProvider services)
    {
        var driver = (StorageCassandraDriver) services.GetRequiredService(typeof(StorageCassandraDriver));
        driver.PrepareSchemas();

        MappingConfiguration.Global.Define<CassandraMappers>();

        return services;
    }
}