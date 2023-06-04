namespace OpusMastery.Admin.Controllers.V1.Employee.Dto;

public class EmployeeCreationDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Position { get; set; }
    public required DateOnly JoiningDate { get; set; }
    public string Role { get; set; } = "Worker";
    public string? Phone { get; set; }
    public string? DepartmentName { get; set; }
}