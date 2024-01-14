using Api.Exceptions;
using Core;
using Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureRepositories();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(new ExceptionHandlerOptions
{
    ExceptionHandler = new StorageExceptionHandler().Invoke
});

app.MapControllers();

app.Run();
