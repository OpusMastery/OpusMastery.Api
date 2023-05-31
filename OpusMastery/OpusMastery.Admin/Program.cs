using OpusMastery.Admin.Extensions;
using OpusMastery.Di.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add environmental configuration to the DI container
var applicationSettings = builder
    .AddConfigurationProviders()
    .AddApplicationSettings();

// Core dependencies
builder.Services
    .AddControllersWithFilters()
    .AddMiddlewares()
    .AddJwtValidation(applicationSettings.JwtSettings)
    .AddCorsPolicies()
    .AddHealthChecks();

// Infrastructure dependencies
builder.Services.AddDatabase(applicationSettings);

// Business dependencies
builder.Services.AddBusinessServices();

WebApplication application = builder.Build();
await application.InitializeDatabaseAsync();

if (application.Environment.IsDevelopment())
{
    application.UseHttpsRedirection();
}

application.UseCors();
application.UseAuthentication();

application.UseMiddlewares();
application.UseHealthChecks("/api/health");
application.MapControllers();

await application.RunAsync();