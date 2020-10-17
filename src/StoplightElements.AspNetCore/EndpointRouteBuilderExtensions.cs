using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace StoplightElements.AspNetCore
{
    public static class EndpointRouteBuilderExtensions
    {
        public static void MapStoplightElements(this IEndpointRouteBuilder routeBuilder, string basePath)
        {
            var options = routeBuilder.ServiceProvider.GetRequiredService<StoplightElementsOptions>();

            var pipeline = routeBuilder.CreateApplicationBuilder()
                .UseMiddleware<StoplightElementsMiddleware>()
                .Build();

            routeBuilder.Map(basePath.TrimEnd('/') + "/{*innerPath}", pipeline);
        }

        public static void MapOpenApiDocument(this IEndpointRouteBuilder routeBuilder, string path, OpenApiFile file)
        {
            routeBuilder.MapGet(path, async context =>
            {
                context.Response.StatusCode = StatusCodes.Status200OK;
                await context.Response.WriteAsync(file.Content);
            });
        }
    }
}
