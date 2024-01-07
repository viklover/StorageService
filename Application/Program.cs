using Application.Api.Storage;
using Application.Services.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// temporarily no data structure yet
builder.Services.AddSingleton<IStorageService, FakeStorageService>();

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
