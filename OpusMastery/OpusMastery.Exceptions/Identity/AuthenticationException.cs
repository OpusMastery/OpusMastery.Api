using System.Net;
using OpusMastery.Exceptions.Abstractions;

namespace OpusMastery.Exceptions.Identity;

public class AuthenticationException : ApplicationExceptionBase
{
    public override HttpStatusCode StatusCode => HttpStatusCode.Forbidden;

    public AuthenticationException() : base("Something went wrong. Check your login details or register first") { }
}