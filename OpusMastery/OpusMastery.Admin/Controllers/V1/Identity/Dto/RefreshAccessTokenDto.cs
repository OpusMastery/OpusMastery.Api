using System.ComponentModel.DataAnnotations;

namespace OpusMastery.Admin.Controllers.V1.Identity.Dto;

public class RefreshAccessTokenDto
{
    [Required]
    public required Guid UserId { get; set; }

    [Required(AllowEmptyStrings = false)]
    public required string RefreshToken { get; set; }
}