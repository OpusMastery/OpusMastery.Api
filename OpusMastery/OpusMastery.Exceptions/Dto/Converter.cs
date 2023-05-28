using OpusMastery.Exceptions.Abstractions;
using OpusMastery.Extensions;

namespace OpusMastery.Exceptions.Dto;

public static class Converter
{
    public static UserExceptionDto ToDto(this ApplicationExceptionBase applicationException)
    {
        return new UserExceptionDto { StatusCode = applicationException.StatusCode.ToInt32(), Message = applicationException.UserMessage };
    }
}