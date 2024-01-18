using Api.Exceptions;
using Core;
using Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddConsole());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureServices();
builder.Services.ConfigureRepositories();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Services.PrepareRepositories();

app.UseExceptionHandler(new ExceptionHandlerOptions
{
    ExceptionHandler = new StorageExceptionHandler().Invoke
});

app.MapControllers();

app.Run();
