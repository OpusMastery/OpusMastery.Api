using OpusMastery.Exceptions.Abstractions;
using OpusMastery.Extensions;

namespace OpusMastery.Exceptions.Dto;

public static class Converter
{
    public static ExceptionDto ToDto(this ApplicationExceptionBase applicationException)
    {
        return new ExceptionDto { StatusCode = applicationException.StatusCode.ToInt32(), UserMessage = applicationException.UserMessage };
    }
}