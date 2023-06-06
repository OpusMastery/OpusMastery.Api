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
}