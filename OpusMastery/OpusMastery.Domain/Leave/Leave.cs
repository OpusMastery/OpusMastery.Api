namespace OpusMastery.Domain.Leave;

public class Leave
{
    public Employee Employee { get; private set; }
    public LeaveType Type { get; private set; }
    public LeaveStatus Status { get; private set; }
    public DateTime AppliedOn { get; private set; }
    public DateTime AppliedFrom { get; private set; }
    public DateTime AppliedTo { get; private set; }
    public string? Reason { get; private set; }

    private Leave(
        Employee employee,
        LeaveType type,
        LeaveStatus status,
        DateTime appliedOn,
        DateTime appliedFrom,
        DateTime appliedTo,
        string? reason)
    {
        Employee = employee;
        Type = type;
        Status = status;
        AppliedOn = appliedOn;
        AppliedFrom = appliedFrom;
        AppliedTo = appliedTo;
        Reason = reason;
    }

    public void SetEmployee(Guid employeeId)
    {
        Employee = Employee.Create(employeeId);
    }

    public static Leave CreateNew(LeaveType type, DateTime appliedFrom, DateTime appliedTo, string? reason)
    {
        return new Leave(Employee.Create(Guid.Empty), type, LeaveStatus.Pending, appliedOn: DateTime.UtcNow, appliedFrom, appliedTo, reason);
    }

    public static Leave Create(Employee employee, LeaveType type, LeaveStatus status, DateTime appliedOn, DateTime appliedFrom, DateTime appliedTo, string? reason)
    {
        return new Leave(employee, type, status, appliedOn, appliedFrom, appliedTo, reason);
    }
}