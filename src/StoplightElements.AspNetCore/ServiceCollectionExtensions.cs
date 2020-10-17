using System;
using Microsoft.Extensions.DependencyInjection;

namespace StoplightElements.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
        public static void AddStoplightElements(this IServiceCollection collection, StoplightElementsOptions options)
        {
            collection.AddSingleton(options);

            collection.AddTransient<StoplightElementsMiddleware>();
        }
    }
}
