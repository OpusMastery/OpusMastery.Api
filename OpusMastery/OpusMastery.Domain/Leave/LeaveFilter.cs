using OpusMastery.Extensions;

namespace OpusMastery.Domain.Leave;

public class LeaveFilter
{
    public bool ShowAppliedOnly { get; private set; }
    public List<string> Types { get; private set; }
    public DateTime? AppliedFrom { get; private set; }
    public DateTime? AppliedTo { get; private set; }

    private LeaveFilter(bool showAppliedOnly, List<string> types, DateTime? appliedFrom, DateTime? appliedTo)
    {
        ShowAppliedOnly = showAppliedOnly;
        Types = types;
        AppliedFrom = appliedFrom;
        AppliedTo = appliedTo;
    }

    public static LeaveFilter Create(bool showAppliedOnly, IEnumerable<string>? types, DateTime? appliedFrom, DateTime? appliedTo)
    {
        return new LeaveFilter(showAppliedOnly, types.OrEmptyIfNull(), appliedFrom, appliedTo);
    }
}