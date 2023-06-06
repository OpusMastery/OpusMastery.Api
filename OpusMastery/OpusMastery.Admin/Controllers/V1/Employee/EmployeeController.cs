using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpusMastery.Admin.Controllers.V1.Employee.Dto;
using OpusMastery.Domain.Employee;
using OpusMastery.Domain.Employee.Interfaces;

namespace OpusMastery.Admin.Controllers.V1.Employee;

[ApiController]
[Route("api/v1/employees")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeDetails>>> GetCompanyEmployees([FromHeader, Required] Guid companyId)
    {
        List<EmployeeDetails> employees = await _employeeService.GetAllEmployeesAsync(companyId);
        return Ok(employees.ToEnumerableDto());
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateEmployee([FromHeader, Required] Guid companyId, [FromBody, Required] EmployeeCreationDto employeeCreationDto)
    {
        Guid employeeId = await _employeeService.CreateEmployeeAsync(employeeCreationDto.ToDomain(companyId));
        return Ok(employeeId.ToString());
    }
}