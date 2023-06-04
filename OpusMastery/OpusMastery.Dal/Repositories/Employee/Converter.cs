using OpusMastery.Domain.Employee;
using OpusMastery.Extensions;
using EmployeeRoleDal = OpusMastery.Dal.Models.EmployeeRole;
using EmployeeDal = OpusMastery.Dal.Models.Employee;

namespace OpusMastery.Dal.Repositories.Employee;

public static class Converter
{
    public static EmployeeRole ToDomain(this EmployeeRoleDal employeeRoleDal)
    {
        return EmployeeRole.Create(employeeRoleDal.Id, employeeRoleDal.Name);
    }

    public static List<EmployeeDetails> ToEnumerableDomain(this IEnumerable<EmployeeDal> employeesDal)
    {
        return employeesDal.Select(ToDomain).ToList();
    }

    public static EmployeeDal ToDal(this EmployeeDetails employeeDetails)
    {
        return new EmployeeDal
        {
            UserId = employeeDetails.UserId,
            CompanyId = employeeDetails.CompanyId,
            RoleId = employeeDetails.Role!.Id,
            ContactEmail = employeeDetails.Email,
            Position = employeeDetails.Position,
            Status = employeeDetails.Status.ToEnumName(),
            JoiningDate = employeeDetails.JoiningDate,
            ContactPhone = employeeDetails.Phone,
            DepartmentName = employeeDetails.DepartmentName
        };
    }

    private static EmployeeDetails ToDomain(this EmployeeDal employeeDal)
    {
        return EmployeeDetails.Create(
            employeeDal.UserId,
            employeeDal.CompanyId,
            employeeDal.User.FirstName,
            employeeDal.User.LastName,
            employeeDal.ContactEmail,
            employeeDal.Position,
            employeeDal.Status.ToEnum<EmployeeStatus>(),
            employeeDal.JoiningDate,
            employeeDal.Role.ToDomain(),
            employeeDal.ContactPhone,
            employeeDal.DepartmentName);
    }
}