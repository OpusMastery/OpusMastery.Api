using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OpusMastery.Configuration;

namespace OpusMastery.Di.Extensions;

public static class ConfigurationDependencies
{
    public static WebApplicationBuilder AddConfigurationProviders(this WebApplicationBuilder builder)
    {
        builder.Configuration
            .SetBasePath(builder.Environment.ContentRootPath)
            .AddEnvironmentVariables()
            .AddJsonFile("", optional: false, reloadOnChange: true);
        
        return builder;
    }

    public static ApplicationSettings AddApplicationSettings(this WebApplicationBuilder builder)
    {
        ApplicationSettings applicationSettings = new();
        
        builder.Configuration.Bind(ApplicationSettings.Key, applicationSettings);
        builder.Services.Configure<ApplicationSettings>(builder.Configuration.GetRequiredSection(ApplicationSettings.Key));
        
        return applicationSettings;
    }
}