﻿using OpusMastery.Domain.Employee;
using OpusMastery.Domain.Identity;
using OpusMastery.Extensions;
using EmployeeRoleDal = OpusMastery.Dal.Models.EmployeeRole;
using EmployeeDal = OpusMastery.Dal.Models.Employee;

namespace OpusMastery.Dal.Repositories.Employee;

public static class Converter
{
    public static List<EmployeeDetails> ToEnumerableDomain(this IEnumerable<EmployeeDal> employeesDal)
    {
        return employeesDal.Select(ToDomain).ToList();
    }

    public static EmployeeDal ToDal(this EmployeeDetails employeeDetails)
    {
        return new EmployeeDal
        {
            Id = employeeDetails.Id,
            UserId = CurrentContextIdentity.User.GetUserIdOrThrow(),
            CompanyId = employeeDetails.CompanyId,
            RoleId = EmployeeRoleManager.GetRoleIdByName(employeeDetails.Role),
            ContactEmail = employeeDetails.Email,
            Position = employeeDetails.Position,
            Status = employeeDetails.Status.ToEnumName(),
            JoiningDate = employeeDetails.JoiningDate,
            ContactPhone = employeeDetails.Phone,
            DepartmentName = employeeDetails.DepartmentName
        };
    }

    public static EmployeeDetails ToDomain(this EmployeeDal employeeDal)
    {
        return EmployeeDetails.Create(
            employeeDal.Id,
            employeeDal.CompanyId,
            employeeDal.User.FirstName,
            employeeDal.User.LastName,
            employeeDal.ContactEmail,
            employeeDal.Position,
            employeeDal.Status.ToEnum<EmployeeStatus>(),
            employeeDal.JoiningDate,
            employeeDal.Role.Name.ToEnum<EmployeeRole>(),
            employeeDal.ContactPhone,
            employeeDal.DepartmentName);
    }
}