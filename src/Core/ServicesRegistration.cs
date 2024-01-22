using Core.Storage.Impl;
using Core.Storage.Impl.Tree;
using Core.Storage.Impl.Tree.Trees;
using Core.Storage.Interfaces;

using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class ServicesRegistration
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddSingleton<IStorageService, SplayTreeStorageService>();
        services.AddSingleton<IBinaryTree, SplayTree>();
        services.AddHostedService<StorageBackgroundService>();
        
        return services;
    }
}