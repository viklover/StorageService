using System.Reflection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Extensions;

/// <summary>
/// Swagger configuration extensions
/// </summary>
public static class SwaggerExtensions
{
    /// <summary>
    /// Enable swagger documentation based on xml comments
    /// </summary>
    /// <param name="o">SwaggerGenOptions instance</param>
    public static void AddSwaggerDocumentation(this SwaggerGenOptions o)
    {
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        o.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    }
}