using Application.Services.Storage;

using Core.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IStorageService, FakeStorageService>();
        return services;
    }
}