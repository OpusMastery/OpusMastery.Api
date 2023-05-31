using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
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

    [HttpPost("register"), AllowAnonymous]
    public async Task<ActionResult<Guid>> RegisterDemoUser([FromBody, Required] DemoUserRegistrationDto demoUserRegistrationDto)
    {
        Guid registeredUserId = await _identityService.RegisterUserAsync(demoUserRegistrationDto.ToDomain());
        return Ok(registeredUserId.ToString());
    }

    [HttpPost("login"), AllowAnonymous]
    public async Task<ActionResult<AccessCredentialsDto>> Login([FromBody, Required] LoginFormDto loginFormDto)
    {
        var accessCredentials = await _identityService.LoginUserAsync(loginFormDto.ToDomain());
        return Ok(accessCredentials.ToDto());
    }

    [HttpPost("refresh-token"), AllowAnonymous]
    public async Task<ActionResult<AccessCredentialsDto>> RefreshAccessToken([FromBody, Required] RefreshAccessTokenDto refreshAccessTokenDto)
    {
        var accessCredentials = await _identityService.RefreshUserAccessTokenAsync(refreshAccessTokenDto.ToDomain());
        return Ok(accessCredentials.ToDto());
    }
}