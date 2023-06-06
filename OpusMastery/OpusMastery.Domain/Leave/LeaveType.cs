namespace OpusMastery.Domain.Leave;

public static class LeaveTypeManager
{
    private static readonly Dictionary<Guid, LeaveType> ApplicationTypes = new()
    {
        { Constants.Type.VacationTypeId, LeaveType.Vacation },
        { Constants.Type.SickLeaveTypeId, LeaveType.SickLeave },
        { Constants.Type.LeaveWithoutPayTypeId, LeaveType.LeaveWithoutPay }
    };

    public static Guid GetTypeIdByName(LeaveType type)
    {
        return ApplicationTypes.First(x => x.Value == type).Key;
    }
}

public enum LeaveType
{
    Vacation = 1,
    SickLeave,
    LeaveWithoutPay
}