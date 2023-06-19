using OpusMastery.Domain.Identity;
using OpusMastery.Domain.Leave;
using OpusMastery.Domain.Leave.Interfaces;
using LeaveDomain = OpusMastery.Domain.Leave.Leave;

namespace OpusMastery.Application.Services.Leave;

public class LeaveService : ILeaveService
{
    private readonly ILeaveRepository _leaveRepository;

    public LeaveService(ILeaveRepository leaveRepository)
    {
        _leaveRepository = leaveRepository;
    }

    public Task<List<LeaveDomain>> GetFilteredLeaveApplicationsAsync(Guid companyId, LeaveFilter leaveFilter)
    {
        return _leaveRepository.FilterLeaveApplicationsAsync(companyId, leaveFilter);
    }

    public async Task<Guid> CreateLeaveApplicationAsync(Guid companyId, LeaveDomain leave)
    {
        Guid employeeId = await _leaveRepository.GetEmployeeIdAsync(CurrentContextIdentity.User.GetUserIdOrThrow(), companyId);
        leave.SetEmployee(employeeId);
        return await _leaveRepository.AddLeaveApplicationAsync(leave);
    }
}