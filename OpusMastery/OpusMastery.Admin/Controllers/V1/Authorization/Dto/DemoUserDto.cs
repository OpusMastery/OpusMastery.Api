using System.ComponentModel.DataAnnotations;

namespace OpusMastery.Admin.Controllers.V1.Authorization.Dto;

public class DemoUserDto
{
    [Required(AllowEmptyStrings = false)]
    public string Email { get; set; } = null!;

    [Required(AllowEmptyStrings = false)]
    public string FirstName { get; set; } = null!;

    [Required(AllowEmptyStrings = false)]
    public string LastName { get; set; } = null!;
}