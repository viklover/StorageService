using Core.Storage;
using Core.Storage.Impl.SplayTree;

using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class ServicesRegistration
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddSingleton<IStorageService, SplayTreeStorageImpl>();
        return services;
    }
}