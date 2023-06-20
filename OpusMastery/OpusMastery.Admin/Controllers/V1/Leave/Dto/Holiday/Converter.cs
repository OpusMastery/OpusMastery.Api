using OpusMastery.Domain.Leave.Holiday;

namespace OpusMastery.Admin.Controllers.V1.Leave.Dto.Holiday;

public static class Converter
{
    public static HolidayFilter ToDomain(this HolidayFilterDto holidayFilterDto)
    {
        return HolidayFilter.Create(holidayFilterDto.Timezone, holidayFilterDto.EndingDate);
    }

    public static IEnumerable<LocalHolidayDto> ToEnumerableDto(this IEnumerable<LocalHoliday> localHolidays)
    {
        return localHolidays.Select(ToDto);
    }

    private static LocalHolidayDto ToDto(this LocalHoliday localHoliday)
    {
        return new LocalHolidayDto { GlobalName = localHoliday.GlobalName, LocalName = localHoliday.LocalName, Date = localHoliday.Date };
    }
}