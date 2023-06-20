namespace OpusMastery.Admin.Controllers.V1.Employee.Dto;

public class BasicEmployeeDetailsDto
{
    public required string Email { get; set; }
    public required Guid EmployeeId { get; set; }
    public required Guid CompanyId { get; set; }
}