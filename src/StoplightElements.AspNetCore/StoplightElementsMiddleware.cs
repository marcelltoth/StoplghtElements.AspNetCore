using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace StoplightElements.AspNetCore
{
    public class StoplightElementsMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}
