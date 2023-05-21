using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OpusMastery.Admin.Controllers.V1.Authentication;

[ApiController]
[Route("api/v1/authentication")]
[AllowAnonymous]
public class AuthenticationController
{
    public AuthenticationController()
    {
        
    }
}