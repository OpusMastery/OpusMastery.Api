using OpusMastery.Domain;
using OpusMastery.Domain.Employee;
using OpusMastery.Domain.Identity;

namespace OpusMastery.Application.Services.Employee;

public static class Converter
{
    public static User ToIdentityDomain(this EmployeeDetails employeeDetails)
    {
        return User.CreateNew(employeeDetails.Email, DomainConstants.DefaultPassword, employeeDetails.FirstName, employeeDetails.LastName);
    }
}