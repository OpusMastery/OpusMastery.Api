namespace OpusMastery.Admin.Controllers.V1.Employee.Dto;

public class EmployeeDetailsDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Position { get; set; }
    public string? Status { get; set; }
    public DateTime? JoiningDate { get; set; }
    public string? Phone { get; set; }
    public string? DepartmentName { get; set; }
}