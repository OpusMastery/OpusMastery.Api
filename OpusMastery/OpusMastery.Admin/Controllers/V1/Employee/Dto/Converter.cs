using OpusMastery.Domain.Employee;
using OpusMastery.Extensions;

namespace OpusMastery.Admin.Controllers.V1.Employee.Dto;

public static class Converter
{
    public static IEnumerable<EmployeeDetailsDto> ToEnumerableDto(this IEnumerable<EmployeeDetails> employeesDetails)
    {
        return employeesDetails.Select(ToDto);
    }

    public static EmployeeDetails ToDomain(this EmployeeDetailsDto employeeDetailsDto, Guid companyId)
    {
        return EmployeeDetails.CreateNew(
            companyId,
            employeeDetailsDto.FirstName,
            employeeDetailsDto.LastName,
            employeeDetailsDto.Email,
            employeeDetailsDto.Position,
            employeeDetailsDto.JoiningDate?.Date ?? DateTime.UtcNow.Date,
            employeeDetailsDto.Phone,
            employeeDetailsDto.DepartmentName);
    }

    private static EmployeeDetailsDto ToDto(this EmployeeDetails employeeDetails)
    {
        return new EmployeeDetailsDto
        {
            FirstName = employeeDetails.FirstName,
            LastName = employeeDetails.LastName,
            Email = employeeDetails.Email,
            Position = employeeDetails.Position,
            Status = employeeDetails.Status.ToEnumName(),
            JoiningDate = employeeDetails.JoiningDate,
            Phone = employeeDetails.Phone,
            DepartmentName = employeeDetails.DepartmentName
        };
    }
}