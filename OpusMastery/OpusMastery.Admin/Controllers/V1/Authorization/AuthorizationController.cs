using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpusMastery.Admin.Controllers.V1.Authorization.Dto;
using OpusMastery.Domain.Authorization.Interfaces;

namespace OpusMastery.Admin.Controllers.V1.Authorization;

[ApiController]
[Route("api/v1/authorization")]
public class AuthorizationController : ControllerBase
{
    private readonly IAuthorizationService _authorizationService;

    public AuthorizationController(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }

    [HttpPost("demo-user")]
    public async Task<ActionResult<Guid>> CreateDemoUser([FromBody, Required] DemoUserDto demoUserDto)
    {
        Guid registeredUserId = await _authorizationService.RegisterUserAsync(demoUserDto.ToDomain());
        return Ok(registeredUserId.ToString());
    }
}