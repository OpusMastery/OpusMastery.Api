using OpusMastery.Domain.Authorization;
using OpusMastery.Domain.Company;
using OpusMastery.Domain.Company.Interfaces;

namespace OpusMastery.Application.Services.Company;

public class CompanyService : ICompanyService
{
    public Task CreateDemoCompanyAsync(User user)
    {
        throw new NotImplementedException();
    }
}