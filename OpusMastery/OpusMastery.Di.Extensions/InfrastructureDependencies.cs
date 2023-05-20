using Microsoft.Extensions.DependencyInjection;
using OpusMastery.Configuration;
using OpusMastery.Dal.Contexts;
using OpusMastery.Dal.Contexts.Interfaces;

namespace OpusMastery.Di.Extensions;

public static class InfrastructureDependencies
{
    public static IServiceCollection AddDatabase(this IServiceCollection serviceCollection, ApplicationSettings applicationSettings)
    {
        return serviceCollection.AddScoped<IDatabaseContext, DatabaseContext>(
            _ => new DatabaseContext(new ContextOptions { ConnectionString = applicationSettings.DatabaseSettings.ToConnectionString() }));
    }
}