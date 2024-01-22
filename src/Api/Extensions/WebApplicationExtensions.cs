using Api.Exceptions;

namespace Api.Extensions;

/// <summary>
/// Web application configurations extensions
/// </summary>
public static class WebApplicationExtensions
{
    /// <summary>
    /// Enable using custom exception handlers
    /// </summary>
    /// <param name="app">WebApplication instance</param>
    public static void UseCustomExceptionHandlers(this WebApplication app)
    {
        app.UseExceptionHandler(new ExceptionHandlerOptions
        {
            ExceptionHandler = new StorageExceptionHandler().Invoke
        });
    }
}