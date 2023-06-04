using OpusMastery.Domain.Employee;
using OpusMastery.Domain.Employee.Interfaces;
using OpusMastery.Domain.Identity.Interfaces;

namespace OpusMastery.Application.Services.Employee;

public class EmployeeService : IEmployeeService
{
    private readonly IIdentityService _identityService;
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IIdentityService identityService, IEmployeeRepository employeeRepository)
    {
        _identityService = identityService;
        _employeeRepository = employeeRepository;
    }

    public Task<List<EmployeeDetails>> GetAllEmployeesAsync(Guid companyId)
    {
        return _employeeRepository.GetAllEmployeesByCompanyIdAsync(companyId);
    }

    public async Task<Guid> CreateEmployeeAsync(EmployeeDetails employeeDetails)
    {
        var user = await _identityService.GetUserAsync(employeeDetails.Email);
        employeeDetails.SetUserId(user?.Id ?? await _identityService.RegisterUserAsync(employeeDetails.ToIdentityDomain()));

        var employeeRole = await _employeeRepository.GetWorkerRoleAsync();
        employeeDetails.SetRole(employeeRole);

        return await _employeeRepository.AddEmployeeToCompanyAsync(employeeDetails);
    }
}