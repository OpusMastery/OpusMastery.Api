using Microsoft.Extensions.DependencyInjection;
using OpusMastery.Application.Services.Company;
using OpusMastery.Application.Services.Employee;
using OpusMastery.Application.Services.Identity;
using OpusMastery.Application.Services.Leave;
using OpusMastery.Dal.Repositories.Company;
using OpusMastery.Dal.Repositories.Employee;
using OpusMastery.Dal.Repositories.Identity;
using OpusMastery.Dal.Repositories.Leave;
using OpusMastery.Domain.Company.Interfaces;
using OpusMastery.Domain.Employee.Interfaces;
using OpusMastery.Domain.Identity.Interfaces;
using OpusMastery.Domain.Leave.Interfaces;

namespace OpusMastery.Di.Extensions;

public static class BusinessDependencies
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddTransient<IClaimService, ClaimService>()
            .AddTransient<IIdentityService, IdentityService>()
            .AddTransient<IIdentityRepository, IdentityRepository>()
            .AddTransient<ICompanyService, CompanyService>()
            .AddTransient<ICompanyRepository, CompanyRepository>()
            .AddTransient<IEmployeeService, EmployeeService>()
            .AddTransient<IEmployeeRepository, EmployeeRepository>()
            .AddTransient<ILeaveService, LeaveService>()
            .AddTransient<ILeaveRepository, LeaveRepository>();
    }
}