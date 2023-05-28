namespace OpusMastery.Exceptions.Dto;

public class ExceptionDto
{
    public int StatusCode { get; set; }
    public string UserMessage { get; set; } = null!;
}