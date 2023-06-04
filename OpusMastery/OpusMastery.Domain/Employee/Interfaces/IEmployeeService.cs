namespace OpusMastery.Domain.Employee.Interfaces;

public interface IEmployeeService
{
    public Task<List<EmployeeDetails>> GetAllEmployeesAsync(Guid companyId);
    public Task<Guid> CreateEmployeeAsync(EmployeeDetails employeeDetails);
}