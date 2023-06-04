namespace OpusMastery.Domain.Employee.Interfaces;

public interface IEmployeeRepository
{
    public Task<EmployeeRole> GetWorkerRoleAsync();
    public Task<List<EmployeeDetails>> GetAllEmployeesByCompanyIdAsync(Guid companyId);
    public Task<Guid> AddEmployeeToCompanyAsync(EmployeeDetails employeeDetails);
}