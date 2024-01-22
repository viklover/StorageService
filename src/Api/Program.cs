using Core;
using Repository;
using Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddConsole());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o => o.AddSwaggerDocumentation());

builder.Services.ConfigureServices();
builder.Services.ConfigureRepositories();

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
