using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpusMastery.Admin.Controllers.V1.Authorization.Dto;
using OpusMastery.Admin.Controllers.V1.Company.Dto;
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
    public async Task<IActionResult> CreateDemoCompany([FromBody, Required] DemoUserDto demoUserDto)
    {
        await _companyService.CreateDemoCompanyAsync(demoUserDto.ToDomain());
        return Ok();
    }
}