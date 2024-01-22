using System.Net;
using System.Text.Json;
using Core.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Api.Exceptions;

public class StorageExceptionHandler
{
    public async Task Invoke(HttpContext context)
    {
        var ex = context.Features.Get<IExceptionHandlerFeature>()?.Error;
        if (ex == null) return;

        HttpStatusCode statusCode;

        var exType = ex.GetType();

        if (exType == typeof(NotFoundException))
            statusCode = HttpStatusCode.NotFound;
        else if (exType == typeof(TimeoutOccuredException))
            statusCode = HttpStatusCode.ServiceUnavailable;
        else
            statusCode = HttpStatusCode.InternalServerError;

        var error = new
        {
            error = statusCode.ToString(),
            message = ex.Message
        };

        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";

        await using var writer = new StreamWriter(context.Response.Body);
        await writer.WriteAsync(JsonSerializer.Serialize(error));
    }
}