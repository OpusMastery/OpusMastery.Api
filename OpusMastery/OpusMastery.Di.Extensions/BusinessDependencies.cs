using Microsoft.Extensions.DependencyInjection;
using OpusMastery.Application.Services.Company;
using OpusMastery.Application.Services.Identity;
using OpusMastery.Dal.Repositories.Identity;
using OpusMastery.Domain.Company.Interfaces;
using OpusMastery.Domain.Identity.Interfaces;

namespace OpusMastery.Di.Extensions;

public static class BusinessDependencies
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddTransient<IClaimService, ClaimService>()
            .AddTransient<IIdentityService, IdentityService>()
            .AddTransient<IIdentityRepository, IdentityRepository>()
            .AddTransient<ICompanyService, CompanyService>();
    }
}