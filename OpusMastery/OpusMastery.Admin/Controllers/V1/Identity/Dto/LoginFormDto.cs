using System.ComponentModel.DataAnnotations;

namespace OpusMastery.Admin.Controllers.V1.Identity.Dto;

public class LoginFormDto
{
    [EmailAddress(ErrorMessage = "Invalid email")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
    public required string Email { get; set; }

    [MinLength(8, ErrorMessage = "Minimum password length must be 8 characters")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
    public required string Password { get; set; }
}