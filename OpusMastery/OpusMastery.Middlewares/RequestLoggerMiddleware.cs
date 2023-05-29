using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace OpusMastery.Middlewares;

public class RequestLoggerMiddleware : IMiddleware
{
    private readonly ILogger<RequestLoggerMiddleware> _logger;

    public RequestLoggerMiddleware(ILogger<RequestLoggerMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        _logger.LogInformation("Request host: {Host}, path: {Path}", context.Request.Host, context.Request.Path);
        await next(context);
    }
}