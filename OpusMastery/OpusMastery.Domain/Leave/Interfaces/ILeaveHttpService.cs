using OpusMastery.Domain.Leave.Holiday;

namespace OpusMastery.Domain.Leave.Interfaces;

public interface ILeaveHttpService
{
    public Task<List<LocalHoliday>> GetLocalHolidaysAsync(HolidayFilter holidayFilter);
}