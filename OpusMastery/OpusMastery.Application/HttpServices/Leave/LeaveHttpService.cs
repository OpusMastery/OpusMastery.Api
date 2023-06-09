﻿using System.Text.Json;
using NodaTime.TimeZones;
using OpusMastery.Application.HttpServices.Leave.Dto;
using OpusMastery.Domain.Leave.Holiday;
using OpusMastery.Domain.Leave.Interfaces;

namespace OpusMastery.Application.HttpServices.Leave;

public class LeaveHttpService : ILeaveHttpService
{
    private readonly HttpClient _httpClient;

    public LeaveHttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<LocalHoliday>> GetLocalHolidaysAsync(HolidayFilter holidayFilter)
    {
        string userCountryCode = GetUserLocale(holidayFilter.Timezone) ?? "US";
        Stream content = await _httpClient.GetStreamAsync($"https://date.nager.at/api/v3/NextPublicHolidays/{userCountryCode}");

        List<LocalHoliday> localHolidays = (await JsonSerializer.DeserializeAsync<IEnumerable<HolidayDto>>(content)).ToEnumerableDomain();

        return holidayFilter.EndingDate is not null ? localHolidays.Where(holiday => holiday.Date <= holidayFilter.EndingDate).ToList() : localHolidays;
    }

    private static string? GetUserLocale(string timezone)
    {
        TzdbZoneLocation? location = TzdbDateTimeZoneSource.Default.ZoneLocations!.FirstOrDefault(x => x.ZoneId == timezone);
        if (location is not null)
        {
            return location.CountryCode;
        }

        string aliasTimezone = TzdbDateTimeZoneSource.Default.Aliases.First(x => x.Contains(timezone)).Key;
        return TzdbDateTimeZoneSource.Default.ZoneLocations!.FirstOrDefault(x => x.ZoneId == aliasTimezone)?.CountryCode;
    }
}