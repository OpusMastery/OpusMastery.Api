using OpusMastery.Domain.Leave;
using OpusMastery.Extensions;
using LeaveDomain = OpusMastery.Domain.Leave.Leave;

namespace OpusMastery.Admin.Controllers.V1.Leave.Dto;

public static class Converter
{
    public static LeaveFilter ToDomain(this LeaveFilterDto leaveFilterDto)
    {
        return LeaveFilter.Create(
            leaveFilterDto.ShowAppliedOnly,
            leaveFilterDto.Types,
            leaveFilterDto.ApplicationRange?.AppliedFrom,
            leaveFilterDto.ApplicationRange?.AppliedTo);
    }

    public static IEnumerable<LeaveApplicationDto> ToEnumerableDto(this IEnumerable<LeaveDomain> leaves)
    {
        return leaves.Select(ToDto);
    }

    private static LeaveApplicationDto ToDto(this LeaveDomain leave)
    {
        return new LeaveApplicationDto
        {
            EmployeeId = leave.Employee.EmployeeId,
            FirstName = leave.Employee.FirstName!,
            LastName = leave.Employee.LastName!,
            Type = leave.Type.ToEnumName(),
            Status = leave.Status.ToEnumName(),
            AppliedFrom = leave.AppliedFromDate,
            AppliedTo = leave.AppliedToDate,
            Reason = leave.Reason
        };
    }
}