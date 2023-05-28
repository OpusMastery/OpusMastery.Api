using Microsoft.AspNetCore.Mvc;
using OpusMastery.Domain.Company.Interfaces;

namespace OpusMastery.Admin.Controllers.V1.Company;

[ApiController]
[Route("api/v1/company")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpPost("demo")]
    public async Task<IActionResult> CreateDemoCompany()
    {
        return Ok();
    }
}