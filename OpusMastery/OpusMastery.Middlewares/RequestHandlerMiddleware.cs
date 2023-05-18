using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace OpusMastery.Middlewares;

public class RequestHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public RequestHandlerMiddleware(RequestDelegate next, ILogger<RequestHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public Task Invoke(HttpContext context)
    {
        _logger.LogWarning("HttpContext Path: {Path}", context.Request.Path.ToString());
        _logger.LogWarning("HttpContext Host: {Host}", context.Request.Host.Host);
        _logger.LogWarning("HttpContext Client IP: {RemoteIpAddress}", context.Connection.RemoteIpAddress);
        return _next(context);
    }
}