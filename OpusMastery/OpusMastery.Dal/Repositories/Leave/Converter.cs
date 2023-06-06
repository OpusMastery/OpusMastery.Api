using OpusMastery.Dal.Models;
using OpusMastery.Domain.Leave;
using OpusMastery.Extensions;
using EmployeeDal = OpusMastery.Dal.Models.Employee;
using EmployeeDomain = OpusMastery.Domain.Leave.Employee;
using LeaveDomain = OpusMastery.Domain.Leave.Leave;

namespace OpusMastery.Dal.Repositories.Leave;

public static class Converter
{
    public static List<LeaveDomain> ToEnumerableDomain(this IEnumerable<LeaveApplication> leaveApplications)
    {
        return leaveApplications.Select(ToDomain).ToList();
    }

    public static LeaveApplication ToDal(this LeaveDomain leave)
    {
        return new LeaveApplication
        {
            EmployeeId = leave.Employee.Id,
            TypeId = LeaveTypeManager.GetTypeIdByName(leave.Type),
            Status = leave.Status.ToEnumName(),
            AppliedOn = leave.AppliedOn,
            AppliedFromDate = leave.AppliedFrom,
            AppliedToDate = leave.AppliedTo,
            Reason = leave.Reason
        };
    }

    private static LeaveDomain ToDomain(this LeaveApplication leaveApplication)
    {
        return LeaveDomain.Create(
            leaveApplication.Employee.ToDomain(),
            leaveApplication.Type.Name.ToEnum<LeaveType>(),
            leaveApplication.Status.ToEnum<LeaveStatus>(),
            leaveApplication.AppliedOn,
            leaveApplication.AppliedFromDate,
            leaveApplication.AppliedToDate,
            leaveApplication.Reason);
    }

    private static EmployeeDomain ToDomain(this EmployeeDal employee)
    {
        return EmployeeDomain.Create(employee.Id, employee.User.FirstName, employee.User.LastName);
    }
}