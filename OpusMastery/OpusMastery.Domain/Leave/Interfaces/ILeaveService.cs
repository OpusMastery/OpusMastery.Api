namespace OpusMastery.Domain.Leave.Interfaces;

public interface ILeaveService
{
    public Task<List<Leave>> GetFilteredLeaveApplicationsAsync(Guid companyId, LeaveFilter leaveFilter);
    public Task<Guid> CreateLeaveApplicationAsync(Guid companyId, Leave leave);
}