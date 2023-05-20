using OpusMastery.Admin.Extensions;
using OpusMastery.Di.Extensions;
using OpusMastery.Middlewares;

var builder = WebApplication.CreateBuilder(args).AddConfigurationProviders();

// Add services to the DI container
var applicationSettings = builder.AddApplicationSettings();

// Infrastructure dependencies
builder.Services.AddDatabase(applicationSettings);

// Core dependencies
builder.Services.AddControllers();

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

application.UseMiddleware<RequestLoggerMiddleware>();
application.MapControllers();

await application.RunAsync();