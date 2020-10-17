using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace StoplightElements.AspNetCore
{
    public class StoplightElementsMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Retrieve the RouteData, and access the route values
            var routeValues = context.GetRouteData().Values;
            context.Response.StatusCode = StatusCodes.Status200OK;
            await context.Response.WriteAsync(routeValues.TryGetValue("innerPath", out object match)
                ? (match?.ToString() ?? "")
                : "Not found");
        }
    }
}
