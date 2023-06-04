using OpusMastery.Domain.Employee;
using OpusMastery.Domain.Identity;
using Constants = OpusMastery.Domain.Identity.Constants;

namespace OpusMastery.Application.Services.Employee;

public static class Converter
{
    public static User ToIdentityDomain(this EmployeeDetails employeeDetails)
    {
        return User.CreateNew(employeeDetails.Email, Constants.DefaultPassword, employeeDetails.FirstName, employeeDetails.LastName);
    }
}