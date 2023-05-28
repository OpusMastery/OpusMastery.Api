using System.ComponentModel.DataAnnotations;

namespace OpusMastery.Admin.Controllers.V1.Identity.Dto;

public class DemoUserRegistrationDto
{
    [Required(AllowEmptyStrings = false)]
    public required string Email { get; set; }

    [Required(AllowEmptyStrings = false)]
    public required string Password { get; set; }

    [Required(AllowEmptyStrings = false)]
    public required string FirstName { get; set; }

    [Required(AllowEmptyStrings = false)]
    public required string LastName { get; set; }
}