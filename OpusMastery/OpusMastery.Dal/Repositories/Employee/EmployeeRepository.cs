﻿using Microsoft.EntityFrameworkCore;
using OpusMastery.Dal.Contexts.Interfaces;
using OpusMastery.Domain.Employee;
using OpusMastery.Domain.Employee.Interfaces;
using EmployeeRoleDal = OpusMastery.Dal.Models.EmployeeRole;
using EmployeeDal = OpusMastery.Dal.Models.Employee;

namespace OpusMastery.Dal.Repositories.Employee;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly IDatabaseContext _databaseContext;

    public EmployeeRepository(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<List<EmployeeDetails>> GetAllEmployeesByCompanyIdAsync(Guid companyId)
    {
        List<EmployeeDal> employees = await _databaseContext.Set<EmployeeDal>()
            .AsNoTracking()
            .Include(x => x.User)
            .Include(x => x.Company)
            .Include(x => x.Role)
            .Where(employee => employee.CompanyId == companyId)
            .ToListAsync();

        return employees.ToEnumerableDomain();
    }

    public async Task<Guid> AddEmployeeToCompanyAsync(Guid userId, EmployeeDetails employeeDetails)
    {
        var employee = employeeDetails.ToDal(userId);
        await _databaseContext.SaveNewAsync(employee);
        return employee.Id;
    }
}