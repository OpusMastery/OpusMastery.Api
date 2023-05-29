using OpusMastery.Admin.Extensions;
using OpusMastery.Di.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add environmental configuration to the DI container
var applicationSettings = builder
    .AddConfigurationProviders()
    .AddApplicationSettings();

// Infrastructure dependencies
builder.Services.AddDatabase(applicationSettings);

// Core dependencies
builder.Services
    .AddControllersWithFilters()
    .AddMiddlewares();

// Business dependencies
builder.Services.AddBusinessServices();

// Swagger dependencies
//builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

WebApplication application = builder.Build();

await application.InitializeDatabaseAsync();

// Configure the HTTP request pipeline
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

application.UseHttpsRedirection();
application.UseAuthorization();

application.UseMiddlewares();
application.MapControllers();

await application.RunAsync();