﻿using EpedimiologicReport.api.Middleware;
using System.Net;

namespace EpedimiologicReport.api.Middleware
{
    public class HandlerErrorsMiddleware
    {
        private RequestDelegate _next;
        private ILogger<HandlerErrorsMiddleware> _ILogger;

        public HandlerErrorsMiddleware(RequestDelegate next, ILogger<HandlerErrorsMiddleware> ILogger)
        {
            _next = next;
            _ILogger = ILogger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
                if (httpContext.Response.StatusCode > 400 && httpContext.Response.StatusCode < 500)
                {
                    throw new KeyNotFoundException(httpContext.Response.StatusCode.ToString());
                }
            }
            catch (Exception error)
            {
                var response = httpContext.Response;
                response.ContentType = "application/json";
                _ILogger.Log(LogLevel.Error, error.Message);
                switch (error)
                {
                    case ArgumentNullException e:
                        // custom application error
                        await response.WriteAsync("Oppps... \n the argument {e.Message} is null!");
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException e:
                        // not found error
                        await response.WriteAsync("Oppps... \n Page Not Found!");
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        // unhandled error
                        await response.WriteAsync("Oppps... \n we are trying to fix the problem!");
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
            }
        }
    }
}
public static class HandlerErrorsMiddlewareExtensions
{
    public static IApplicationBuilder UseHandlerErrorsMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<HandlerErrorsMiddleware>();
    }
}
