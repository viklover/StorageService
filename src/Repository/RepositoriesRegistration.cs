using Cassandra.Mapping;
using Core.Storage.Interfaces;
using Repository.Configurations;

using Microsoft.Extensions.DependencyInjection;

namespace Repository;

using Storage;

public static class RepositoriesRegistration
{
    public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IStorageRepository, StorageRepository>();
        services.AddSingleton<StorageCassandraDriver, StorageCassandraDriver>();
        return services;
    }

    public static IServiceProvider PrepareRepositories(this IServiceProvider services)
    {
        var repository = (StorageRepository) services.GetRequiredService(typeof(IStorageRepository));
        repository.PrepareSchemas();

        MappingConfiguration.Global.Define<CassandraMappers>();

        return services;
    }
}