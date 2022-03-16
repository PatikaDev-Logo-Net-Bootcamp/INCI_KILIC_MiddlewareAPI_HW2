using INCI_KILIC_MiddlewareAPI_HW2.AppVersionMiddleware;
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
            var appVersion = new Version(_configuration.GetValue<string>("app-version"));
            var inputVersion = new Version(httpContext.Request.Headers["app-version"]);

            try
            {
                if (httpContext.Request.Path == "/register" || httpContext.Request.Path == "/login")
                {
                    await _next(httpContext);
                }
                else if (appVersion.CompareTo(inputVersion) > 0)
                {
                    httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await httpContext.Response.WriteAsync("401 Unauthorized Error!");
                }
            }
            catch (Exception exception)
            {
                await InternalServerError(httpContext, exception);
            }
        }

        private async Task InternalServerError(HttpContext http_Context, Exception ex)
        {
            http_Context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await http_Context.Response.WriteAsync("Error! " + ex.Message);
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