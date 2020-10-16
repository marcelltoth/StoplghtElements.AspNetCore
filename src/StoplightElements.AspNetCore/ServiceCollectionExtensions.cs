using System;
using Microsoft.Extensions.DependencyInjection;

namespace StoplightElements.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
        public static void AddStoplightElements(this IServiceCollection collection)
        {
            collection.AddTransient<StoplightElementsMiddleware>();
        }
    }
}
