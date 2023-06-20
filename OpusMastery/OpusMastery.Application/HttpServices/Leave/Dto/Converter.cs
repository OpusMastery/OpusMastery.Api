using OpusMastery.Domain.Leave.Holiday;
using OpusMastery.Extensions;

namespace OpusMastery.Application.HttpServices.Leave.Dto;

public static class Converter
{
    public static List<LocalHoliday> ToEnumerableDomain(this IEnumerable<HolidayDto>? holidaysDto)
    {
        return holidaysDto.OrEmptyIfNull().Select(ToDomain).Where(holiday => holiday.Date >= DateOnly.FromDateTime(DateTime.UtcNow)).ToList();
    }

    private static LocalHoliday ToDomain(this HolidayDto holidayDto)
    {
        return LocalHoliday.Create(holidayDto.GlobalName, holidayDto.LocalName, holidayDto.Date);
    }
}