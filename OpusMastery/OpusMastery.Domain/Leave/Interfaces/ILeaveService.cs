using LeaveDomain = OpusMastery.Domain.Leave.Leave;

namespace OpusMastery.Domain.Leave.Interfaces;

public interface ILeaveService
{
    public Task<List<LeaveDomain>> GetFilteredLeaveApplicationsAsync(Guid companyId, LeaveFilter leaveFilter);
}