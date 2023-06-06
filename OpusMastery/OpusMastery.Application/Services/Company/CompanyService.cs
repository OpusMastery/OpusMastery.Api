using OpusMastery.Domain.Company.Interfaces;

namespace OpusMastery.Application.Services.Company;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyService(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }
}