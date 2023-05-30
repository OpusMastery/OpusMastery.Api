using System.Net;
using OpusMastery.Exceptions.Abstractions;

namespace OpusMastery.Exceptions.Identity;

public class UserAlreadyExistsException : ApplicationExceptionBase
{
    public override HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public UserAlreadyExistsException(string email) : base($"The user with email: {email} has been already registered") { }
}