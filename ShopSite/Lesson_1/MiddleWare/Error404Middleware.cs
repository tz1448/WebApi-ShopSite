using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Error404Middleware
{
    private readonly RequestDelegate _next;

    public Error404Middleware(RequestDelegate next)
    {
        _next = next;
    }

        public async Task Invoke(HttpContext httpContext)
    {
           
            if (httpContext.Response.StatusCode == 404)
            {
                httpContext.Response.ContentType = "text/html";
                httpContext.Response.ContentType = "text/html";
                httpContext.Response.SendFileAsync("M:\\API\\ShopSite\\ShopSite\\Lesson_1\\wwwroot\\Error404.html");
            }
         
           
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class Error404MiddlewareExtensions
{
    public static IApplicationBuilder UseError404Middleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<Error404Middleware>();
    }
}
}
