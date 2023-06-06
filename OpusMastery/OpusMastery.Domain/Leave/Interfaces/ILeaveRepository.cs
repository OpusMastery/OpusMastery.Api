using LeaveDomain = OpusMastery.Domain.Leave.Leave;

namespace OpusMastery.Domain.Leave.Interfaces;

public interface ILeaveRepository
{
    public Task<Guid> GetEmployeeIdAsync(Guid userId, Guid companyId);
    public Task<List<LeaveDomain>> FilterLeaveApplicationsAsync(Guid companyId, LeaveFilter leaveFilter);
    public Task<Guid> AddLeaveApplicationAsync(LeaveDomain leave);
}