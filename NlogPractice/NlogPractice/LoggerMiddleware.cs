using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NlogPractice
{
    public class LoggerMiddleware
    {
        private readonly ILogger<LoggerMiddleware> logger;
        private readonly RequestDelegate next;

        public LoggerMiddleware(ILogger<LoggerMiddleware> logger, RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Items["CorrelationId"] = Guid.NewGuid().ToString();
            logger.LogInformation($"About to Start {httpContext.Request.Method} {httpContext.Request.GetDisplayUrl()} request");

            await next(httpContext);

            logger.LogInformation($"Request Complete with status code: {httpContext.Response.StatusCode}");
        }
    }

    public static class LoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggerMiddleware>();
        }

    }
}
