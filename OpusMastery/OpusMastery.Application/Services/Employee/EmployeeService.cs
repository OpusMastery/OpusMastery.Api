using OpusMastery.Domain.Employee;
using OpusMastery.Domain.Employee.Interfaces;
using OpusMastery.Domain.Identity;
using OpusMastery.Domain.Identity.Interfaces;

namespace OpusMastery.Application.Services.Employee;

public class EmployeeService : IEmployeeService
{
    private readonly IIdentityService _identityService;
    private readonly IIdentityRepository _identityRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IIdentityService identityService, IIdentityRepository identityRepository, IEmployeeRepository employeeRepository)
    {
        _identityService = identityService;
        _identityRepository = identityRepository;
        _employeeRepository = employeeRepository;
    }

    public Task<List<EmployeeDetails>> GetAllEmployeesAsync(Guid companyId)
    {
        return _employeeRepository.GetAllEmployeesByCompanyIdAsync(companyId);
    }

    public async Task<Guid> CreateEmployeeAsync(EmployeeDetails employeeDetails)
    {
        var user = await _identityRepository.GetUserByEmailAsync(employeeDetails.Email);
        Guid userId = user?.Id ?? await _identityService.RegisterUserAsync(employeeDetails.ToIdentityDomain());

        CurrentContextIdentity.User = UserIdentifier.Create(userId);
        return await _employeeRepository.AddEmployeeToCompanyAsync(employeeDetails);
    }
}