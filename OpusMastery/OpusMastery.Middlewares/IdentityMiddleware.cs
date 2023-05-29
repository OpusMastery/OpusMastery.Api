using Microsoft.AspNetCore.Http;
using OpusMastery.Domain.Identity;
using OpusMastery.Extensions;

namespace OpusMastery.Middlewares;

public class IdentityMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        string? userId = context.User.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;

        using (CurrentContextIdentity.SetIdentifier(UserIdentifier.Create(userId.ToGuidOrDefault())))
        {
            await next(context);
        }
    }
}