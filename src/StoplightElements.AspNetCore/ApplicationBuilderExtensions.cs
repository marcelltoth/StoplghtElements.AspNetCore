using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace StoplightElements.AspNetCore
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseStoplightElements(this IApplicationBuilder appBuilder)
        {
            return appBuilder.UseMiddleware<StoplightElementsMiddleware>();
        }

        public static void MapOpenApiDocument(this IEndpointRouteBuilder routeBuilder, OpenApiFile file)
        {
            MapOpenApiDocument(routeBuilder, new ServeOpenApiDocumentOptions(file));
        }

        public static void MapOpenApiDocument(this IEndpointRouteBuilder routeBuilder, ServeOpenApiDocumentOptions options)
        {

            routeBuilder.MapGet(options.Path, async context =>
            {
                context.Response.StatusCode = StatusCodes.Status200OK;
                await context.Response.WriteAsync(options.ApiDescription.Content);
            });
        }
    }
}
