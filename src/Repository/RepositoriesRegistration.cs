using Core.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Repository;

using Storage;

public static class RepositoriesRegistration
{
    public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IStorageRepository<uint>, StorageRepository>();
        services.AddSingleton<StorageCassandraDriver, StorageCassandraDriver>();
        return services;
    }

    public static IServiceProvider PrepareRepositories(this IServiceProvider services)
    {
        var repository = (StorageRepository) services.GetRequiredService(typeof(IStorageRepository<uint>));
        repository.PrepareSchemas();
        return services;
    }
}