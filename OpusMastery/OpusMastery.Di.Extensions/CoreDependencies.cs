using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OpusMastery.Application.Extensions;
using OpusMastery.Configuration;
using OpusMastery.Domain;
using OpusMastery.Middlewares;
using OpusMastery.Middlewares.Formatters;

namespace OpusMastery.Di.Extensions;

public static class CoreDependencies
{
    public static IServiceCollection AddControllersWithFilters(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddControllers(options => options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()))).Services;
    }

    public static IServiceCollection AddMiddlewares(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddScoped<IdentityMiddleware>()
            .AddScoped<RequestLoggerMiddleware>();
    }

    public static IServiceCollection AddJwtValidation(this IServiceCollection serviceCollection, JwtSettings jwtSettings)
    {
        return serviceCollection
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.IncludeErrorDetails = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IncludeTokenOnFailedValidation = true,
                    AuthenticationType = DomainConstants.JwtAuthenticationType,
                    ValidAlgorithms = new [] { SecurityAlgorithms.HmacSha512 },
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = jwtSettings.SecretKey.GetSecurityKey()
                };
            }).Services;
    }
}