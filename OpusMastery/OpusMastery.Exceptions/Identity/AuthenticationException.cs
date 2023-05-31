using System.Net;
using OpusMastery.Exceptions.Abstractions;

namespace OpusMastery.Exceptions.Identity;

public class AuthenticationException : ApplicationExceptionBase
{
    public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;

    public AuthenticationException(string? userMessage = null) : base(userMessage ?? "Something went wrong. Check your login details or register first.") { }
}