using Microsoft.Extensions.DependencyInjection;
using OpusMastery.Application.Services.Authorization;
using OpusMastery.Application.Services.Company;
using OpusMastery.Dal.Repositories.Authorization;
using OpusMastery.Domain.Authorization.Interfaces;
using OpusMastery.Domain.Company.Interfaces;

namespace OpusMastery.Di.Extensions;

public static class BusinessDependencies
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddTransient<IAuthorizationService, AuthorizationService>()
            .AddTransient<IAuthorizationRepository, AuthorizationRepository>()
            .AddTransient<ICompanyService, CompanyService>();
    }
}