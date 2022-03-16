using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INCI_KILIC_MiddlewareAPI_HW2.AppVersionMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AppVersionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public AppVersionMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                var currentVersion = new Version(_configuration.GetValue<string>("app-version"));
                var versionFromRequest = new Version(httpContext.Request.Headers["app-version"]);

                if (httpContext.Request.Path == "/register" || httpContext.Request.Path == "/login")
                {
                    await _next(httpContext);
                }

                else if (currentVersion.CompareTo(versionFromRequest) < 0)
                {
                    httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await httpContext.Response.WriteAsync("401 Unauthorized Error!");
                }

                else
                {
                    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await httpContext.Response.WriteAsync("500 Internal Server Error!");
                }
            }

            catch
            {
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AppVersionMiddlewareExtensions
    {
        public static IApplicationBuilder UseAddVersionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AppVersionMiddleware>();
        }
    }
}
