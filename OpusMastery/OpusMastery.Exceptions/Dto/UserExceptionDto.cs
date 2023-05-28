namespace OpusMastery.Exceptions.Dto;

public class UserExceptionDto
{
    public required int StatusCode { get; set; }
    public required string Message { get; set; }
}