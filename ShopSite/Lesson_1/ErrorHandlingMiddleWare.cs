using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Lesson1_login
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrorHandlingMiddleWare
{

        private readonly RequestDelegate _next;
        ILogger<ErrorHandlingMiddleWare> _logger;

    public ErrorHandlingMiddleWare(RequestDelegate next, ILogger<ErrorHandlingMiddleWare> logger)
    {
        _next = next;
        _logger = logger;
    }

   
        public async Task Invoke(HttpContext httpContext)
    {

        try{ 
        
            await _next(httpContext);
        }
        catch(Exception e)
        {

                //_logger.LogWarning()
                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsync("Internal server error");

            }


    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class MiddleWareExtensions
{
    public static IApplicationBuilder UseErrorHandlingMiddleWare(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorHandlingMiddleWare>();
    }
}
}
