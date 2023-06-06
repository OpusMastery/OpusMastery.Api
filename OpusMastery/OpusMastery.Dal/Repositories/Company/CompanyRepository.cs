using OpusMastery.Dal.Contexts.Interfaces;
using OpusMastery.Domain.Company.Interfaces;

namespace OpusMastery.Dal.Repositories.Company;

public class CompanyRepository : ICompanyRepository
{
    private readonly IDatabaseContext _databaseContext;

    public CompanyRepository(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
}