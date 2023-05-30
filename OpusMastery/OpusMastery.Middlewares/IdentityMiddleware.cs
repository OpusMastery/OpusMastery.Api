using Microsoft.AspNetCore.Http;
using OpusMastery.Domain.Identity;
using OpusMastery.Extensions;

namespace OpusMastery.Middlewares;

public class IdentityMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        string? userId = context.User.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;
        var userIdentifier = UserIdentifier.Create(userId.ToGuidOrDefault());

        using (CurrentContextIdentity.SetIdentifier(userIdentifier))
        {
            await next(context);
        }
    }
}