using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace OpusMastery.Middlewares;

public class RequestLoggerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggerMiddleware> _logger;

    public RequestLoggerMiddleware(RequestDelegate next, ILogger<RequestLoggerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation("Request host: {Host}, path: {Path}", context.Request.Host, context.Request.Path);
        return _next(context);
    }
}