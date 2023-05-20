using OpusMastery.Dal.Contexts.Interfaces;

namespace OpusMastery.Admin.Extensions;

public static class ApplicationExtensions
{
    public static Task InitializeDatabaseAsync(this WebApplication application)
    {
        using var scope = application.Services.CreateAsyncScope();
        IDatabaseContext databaseContext = scope.ServiceProvider.GetRequiredService<IDatabaseContext>();
        return databaseContext.InitializeDatabaseAsync();
    }
}