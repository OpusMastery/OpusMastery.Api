using LeaveDomain = OpusMastery.Domain.Leave.Leave;

namespace OpusMastery.Domain.Leave.Interfaces;

public interface ILeaveRepository
{
    public Task<List<LeaveDomain>> FilterLeaveApplicationsAsync(Guid companyId, LeaveFilter leaveFilter);
}