using Core.Storage;
using Core.Storage.Impl.SplayTree;

using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IStorageService, SplayTreeStorageImpl>();
        return services;
    }
}