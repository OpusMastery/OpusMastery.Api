using OpusMastery.Domain.Leave.Holiday;
using OpusMastery.Extensions;

namespace OpusMastery.Application.HttpServices.Dto;

public static class Converter
{
    public static List<LocalHoliday> ToEnumerableDomain(this IEnumerable<HolidayDto>? holidaysDto)
    {
        return holidaysDto.OrEmptyIfNull().Select(ToDomain).ToList();
    }

    private static LocalHoliday ToDomain(this HolidayDto holidayDto)
    {
        return LocalHoliday.Create(holidayDto.GlobalName, holidayDto.LocalName, holidayDto.Date);
    }
}