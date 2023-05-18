using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Services;
using Entities;
using System.Net.Http;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingMiddleWare
    {
        private readonly RequestDelegate _next;
        IRatingRervice _ratingRervice;

        public RatingMiddleWare(RequestDelegate next)
        {
            _next = next;

        }

        public async Task Invoke(HttpContext httpContext, IRatingRervice ratingRervice)
        {

            //_ratingRervice = ratingRervice;
            Rating rating = new Rating()
            {

                Host = httpContext.Request.Host.Host,
                Method = httpContext.Request.Method,
                Path = httpContext.Request.Path,
                Referer = httpContext.Request.Headers.Referer,
                UserAgent = httpContext.Request.Headers.UserAgent,
                RecordDate = DateTime.Now
            };

            await  ratingRervice.AddRating(rating);
            await  _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleWare>();
        }
    }
}
