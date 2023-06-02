using OpusMastery.Dal.Contexts.Interfaces;
using OpusMastery.Middlewares;

namespace OpusMastery.Admin.Extensions;

public static class ApplicationExtensions
{
    public static async Task InitializeDatabaseAsync(this WebApplication application)
    {
        await using var scope = application.Services.CreateAsyncScope();
        IDatabaseContext databaseContext = scope.ServiceProvider.GetRequiredService<IDatabaseContext>();
        await databaseContext.InitializeDatabaseAsync();
    }

    public static void UseMiddlewares(this WebApplication application)
    {
        application.UseMiddleware<IdentityMiddleware>();
        application.UseMiddleware<RequestLoggerMiddleware>();
    }
}