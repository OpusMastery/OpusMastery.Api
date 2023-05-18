using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace OpusMastery.Middlewares;

public class RequestHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestHandlerMiddleware> _logger;

    public RequestHandlerMiddleware(RequestDelegate next, ILogger<RequestHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public Task Invoke(HttpContext context)
    {
        _logger.LogInformation("Request host: {Host}", context.Request.Host.ToString());
        _logger.LogInformation("Request path: {Path}", context.Request.Path.ToString());
        return _next(context);
    }
}