using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpusMastery.Admin.Controllers.V1.Leave.Dto;
using OpusMastery.Admin.Controllers.V1.Leave.Dto.Holiday;
using OpusMastery.Domain.Leave.Holiday;
using OpusMastery.Domain.Leave.Interfaces;

namespace OpusMastery.Admin.Controllers.V1.Leave;

[ApiController]
[Route("api/v1/leaves")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class LeaveController : ControllerBase
{
    private readonly ILeaveService _leaveService;
    private readonly ILeaveHttpService _leaveHttpService;

    public LeaveController(ILeaveService leaveService, ILeaveHttpService leaveHttpService)
    {
        _leaveService = leaveService;
        _leaveHttpService = leaveHttpService;
    }

    [HttpPost("holidays")]
    public async Task<ActionResult<IEnumerable<LocalHolidayDto>>> GetLocalHolidays([FromBody, Required] HolidayFilterDto holidayFilterDto)
    {
        List<LocalHoliday> holidays = await _leaveHttpService.GetLocalHolidaysAsync(holidayFilterDto.ToDomain());
        return Ok(holidays.ToEnumerableDto());
    }

    [HttpPost("filter")]
    public async Task<ActionResult<IEnumerable<LeaveDto>>> FilterLeaveApplications([FromHeader, Required] Guid companyId, [FromBody] LeaveFilterDto leaveFilterDto)
    {
        var filteredLeaves = await _leaveService.GetFilteredLeaveApplicationsAsync(companyId, leaveFilterDto.ToDomain());
        return Ok(filteredLeaves.ToEnumerableDto());
    }

    [HttpPost("apply")]
    public async Task<ActionResult<Guid>> ApplyLeaveApplication([FromHeader, Required] Guid companyId, [FromBody, Required] LeaveCreationDto leaveCreationDto)
    {
        Guid leaveApplicationId = await _leaveService.CreateLeaveApplicationAsync(companyId, leaveCreationDto.ToDomain());
        return Ok(leaveApplicationId.ToString());
    }
}