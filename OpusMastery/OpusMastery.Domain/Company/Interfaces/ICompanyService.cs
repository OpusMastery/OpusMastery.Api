using OpusMastery.Domain.Authorization;

namespace OpusMastery.Domain.Company.Interfaces;

public interface ICompanyService
{
    public Task CreateDemoCompanyAsync(User user);
}