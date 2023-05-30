using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpusMastery.Admin.Controllers.V1.Identity.Dto;
using OpusMastery.Domain.Identity.Interfaces;

namespace OpusMastery.Admin.Controllers.V1.Identity;

[ApiController]
[Route("api/v1/[controller]")]
public class IdentityController : ControllerBase
{
    private readonly IIdentityService _identityService;

    public IdentityController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<Guid>> RegisterDemoUser([FromBody, Required] DemoUserRegistrationDto demoUserRegistrationDto)
    {
        Guid registeredUserId = await _identityService.RegisterUserAsync(demoUserRegistrationDto.ToDomain());
        return Ok(registeredUserId.ToString());
    }
}