using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;

using Application.Api.Storage.Exceptions;

namespace Application.Api.Storage;

public class StorageExceptionHandler
{
    public async Task Invoke(HttpContext context)
    {
        var ex = context.Features.Get<IExceptionHandlerFeature>()?.Error;
        if (ex == null) return;

        var statusCode = ex.GetType() == typeof(NotFoundException)
            ? HttpStatusCode.NotFound
            : HttpStatusCode.InternalServerError;

        var error = new
        {
            error = statusCode.ToString(),
            message = ex.Message
        };

        context.Response.StatusCode = (int) statusCode;
        context.Response.ContentType = "application/json";

        await using var writer = new StreamWriter(context.Response.Body);
        await writer.WriteAsync(JsonSerializer.Serialize(error));
    }
}