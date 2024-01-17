using Core.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Repository;

using Storage;

public static class RepositoriesRegistration
{
    public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IStorageRepository<uint>, StorageRepository>();
        return services;
    }
}