using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpusMastery.Admin.Controllers.V1.Leave.Dto;
using OpusMastery.Domain.Leave.Interfaces;

namespace OpusMastery.Admin.Controllers.V1.Leave;

[ApiController]
[Route("api/v1/leaves")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class LeaveController : ControllerBase
{
    private readonly ILeaveService _leaveService;

    public LeaveController(ILeaveService leaveService)
    {
        _leaveService = leaveService;
    }

    [HttpPost("filter")]
    public async Task<ActionResult<IEnumerable<LeaveApplicationDto>>> FilterLeaveApplications([FromHeader, Required] Guid companyId, [FromBody] LeaveFilterDto leaveFilterDto)
    {
        var filteredLeaves = await _leaveService.GetFilteredLeaveApplicationsAsync(companyId, leaveFilterDto.ToDomain());
        return Ok(filteredLeaves.ToEnumerableDto());
    }
}