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

    public static LeaveDomain ToDomain(this LeaveCreationDto leaveCreationDto)
    {
        return LeaveDomain.CreateNew(leaveCreationDto.Type.ToEnum<LeaveType>(), leaveCreationDto.AppliedFrom, leaveCreationDto.AppliedTo, leaveCreationDto.Reason);
    }

    public static IEnumerable<LeaveDto> ToEnumerableDto(this IEnumerable<LeaveDomain> leaves)
    {
        return leaves.Select(ToDto);
    }

    private static LeaveDto ToDto(this LeaveDomain leave)
    {
        return new LeaveDto
        {
            EmployeeId = leave.Employee.Id,
            FirstName = leave.Employee.FirstName!,
            LastName = leave.Employee.LastName!,
            Type = leave.Type.ToEnumName(),
            Status = leave.Status.ToEnumName(),
            AppliedFrom = leave.AppliedFrom,
            AppliedTo = leave.AppliedTo,
            Reason = leave.Reason
        };
    }
}