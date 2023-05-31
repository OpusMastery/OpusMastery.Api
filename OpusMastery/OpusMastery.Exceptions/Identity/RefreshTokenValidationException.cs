using System.Net;
using OpusMastery.Exceptions.Abstractions;

namespace OpusMastery.Exceptions.Identity;

public class RefreshTokenValidationException : ApplicationExceptionBase
{
    public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;

    public RefreshTokenValidationException(string? userMessage = null) : base(userMessage ?? "The saved refresh token is not valid. Please login again.") { }
}