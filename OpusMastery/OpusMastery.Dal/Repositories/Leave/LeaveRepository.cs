using Microsoft.EntityFrameworkCore;
using OpusMastery.Dal.Contexts.Interfaces;
using OpusMastery.Dal.Models;
using OpusMastery.Domain.Leave;
using OpusMastery.Domain.Leave.Interfaces;
using EmployeeDal = OpusMastery.Dal.Models.Employee;
using LeaveDomain = OpusMastery.Domain.Leave.Leave;
namespace OpusMastery.Dal.Repositories.Leave;

public class LeaveRepository : ILeaveRepository
{
    private readonly IDatabaseContext _databaseContext;

    public LeaveRepository(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<Guid> GetEmployeeIdAsync(Guid userId, Guid companyId)
    {
        return (await _databaseContext.Set<EmployeeDal>().AsNoTracking().FirstAsync(employee => employee.UserId == userId && employee.CompanyId == companyId)).Id;
    }

    public async Task<List<LeaveDomain>> FilterLeaveApplicationsAsync(Guid companyId, LeaveFilter leaveFilter)
    {
        IQueryable<LeaveApplication> unfilteredApplications = _databaseContext.Set<LeaveApplication>()
            .AsNoTracking()
            .Include(x => x.Employee)
                .ThenInclude(x => x.User)
            .Include(x => x.Type)
            .Include(x => x.Status)
            .Where(application => application.Employee.CompanyId == companyId);

        if (leaveFilter.ShowAppliedOnly)
        {
            unfilteredApplications = unfilteredApplications.Where(application => application.Status == nameof(LeaveStatus.Approved));
        }
        if (leaveFilter.Types.Any())
        {
            unfilteredApplications = unfilteredApplications.Where(application => leaveFilter.Types.Contains(application.Type.Name));
        }
        if (leaveFilter.AppliedFrom.HasValue)
        {
            unfilteredApplications = unfilteredApplications.Where(application => application.AppliedFromDate >= leaveFilter.AppliedFrom.Value);
        }
        if (leaveFilter.AppliedTo.HasValue)
        {
            unfilteredApplications = unfilteredApplications.Where(application => application.AppliedToDate <= leaveFilter.AppliedTo.Value);
        }

        return (await unfilteredApplications.ToListAsync()).ToEnumerableDomain();
    }

    public async Task<Guid> AddLeaveApplicationAsync(LeaveDomain leave)
    {
        var leaveApplication = leave.ToDal();
        await _databaseContext.SaveNewAsync(leaveApplication);
        return leaveApplication.Id;
    }
}