namespace OpusMastery.Domain.Employee.Interfaces;

public interface IEmployeeRepository
{
    public Task<EmployeeDetails> GetEmployeeDetailsAsync(Guid userId);
    public Task<List<EmployeeDetails>> GetAllEmployeesByCompanyIdAsync(Guid companyId);
    public Task<Guid> AddEmployeeToCompanyAsync(EmployeeDetails employeeDetails);
}