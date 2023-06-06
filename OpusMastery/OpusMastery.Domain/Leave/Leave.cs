namespace OpusMastery.Domain.Leave;

public class Leave
{
    public Employee Employee { get; private set; }
    public LeaveType Type { get; private set; }
    public LeaveStatus Status { get; private set; }
    public DateTime AppliedOn { get; private set; }
    public DateTime AppliedFromDate { get; private set; }
    public DateTime AppliedToDate { get; private set; }
    public string? Reason { get; private set; }

    private Leave(
        Employee employee,
        LeaveType type,
        LeaveStatus status,
        DateTime appliedOn,
        DateTime appliedFromDate,
        DateTime appliedToDate,
        string? reason)
    {
        Employee = employee;
        Type = type;
        Status = status;
        AppliedOn = appliedOn;
        AppliedFromDate = appliedFromDate;
        AppliedToDate = appliedToDate;
        Reason = reason;
    }

    public static Leave Create(
        Employee employee,
        LeaveType type,
        LeaveStatus status,
        DateTime appliedOn,
        DateTime appliedFromDate,
        DateTime appliedToDate,
        string? reason)
    {
        return new Leave(employee, type, status, appliedOn, appliedFromDate, appliedToDate, reason);
    }
}