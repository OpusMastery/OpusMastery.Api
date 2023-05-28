using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.DependencyInjection;
using OpusMastery.Middlewares;

namespace OpusMastery.Di.Extensions;

public static class CoreDependencies
{
    public static IServiceCollection AddControllersWithFilters(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddControllers(options => options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()))).Services;
    }
}