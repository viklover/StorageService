using Core.Storage.Impl.Tree;
using Core.Storage.Impl.Tree.Updates;
using Core.Storage.Interfaces;
using Core.Storage.Interfaces.Updates;

using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class ServicesRegistration
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddSingleton<IStorageService, SplayTreeStorageService>();
        services.AddSingleton<IStorageUpdatesService<uint>, StorageUpdatesService>();
        return services;
    }
}