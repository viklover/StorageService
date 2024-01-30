using Repository;
using Api.Extensions;
using Core.Storage.Impl;
using Core.Storage.Impl.Tree;
using Core.Storage.Impl.Tree.Trees;
using Core.Storage.Interfaces;
using Repository.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddConsole());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o => o.AddSwaggerDocumentation());

// storage service
builder.Services.AddSingleton<IStorageService, SplayTreeStorageService>();
builder.Services.AddSingleton<IBinaryTree, SplayTree>();
builder.Services.AddHostedService<StorageBackgroundService>();

// repositories
builder.Services.AddSingleton<IStorageRepository, StorageRepository>();
builder.Services.AddSingleton<StorageCassandraDriver, StorageCassandraDriver>();

var app = builder.Build();

app.Services.PrepareRepositories();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionHandlers();

app.MapControllers();

app.Run();
