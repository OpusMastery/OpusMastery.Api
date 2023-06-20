using System.Text.Json.Serialization;

namespace OpusMastery.Application.HttpServices.Dto;

public class HolidayDto
{
    [JsonPropertyName("name")]
    public required string GlobalName { get; set; }

    [JsonPropertyName("localName")]
    public required string LocalName { get; set; }

    [JsonPropertyName("date")]
    public required DateOnly Date { get; set; }
}