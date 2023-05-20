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
            .AddEnvironmentVariables()
            .AddJsonFile(string.Empty);
        
        return builder;
    }

    public static ApplicationSettings AddApplicationSettings(this WebApplicationBuilder builder)
    {
        ApplicationSettings applicationSettings = new();
        
        builder.Configuration.Bind(ApplicationSettings.ApplicationSettingsKey, applicationSettings);
        builder.Services.Configure<ApplicationSettings>(builder.Configuration.GetRequiredSection(ApplicationSettings.ApplicationSettingsKey));
        
        return applicationSettings;
    }
}