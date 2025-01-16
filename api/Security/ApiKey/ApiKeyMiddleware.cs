using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Security.ApiKey
{
    public class ApiKeyMiddleware
    {
    private readonly RequestDelegate _next;
    private readonly string? _apiKey;
    public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _apiKey = configuration["testApi"];
        
    }
        
        public async Task Invoke(HttpContext context)
        {            
            if (!context.Request.Headers.TryGetValue("X-API-Key", out var apiKey))
            {                
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("API Key Missing");
                return;
            }

            if (apiKey != _apiKey)
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Invalid API Key");
                return;
            }

            await _next(context);
        }
    }
}