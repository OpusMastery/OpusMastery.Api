using System.Net;
using OpusMastery.Exceptions.Abstractions;

namespace OpusMastery.Exceptions.Identity;

public class UserNotFoundException : ApplicationExceptionBase
{
    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;

    public UserNotFoundException(string userMessage) : base(userMessage) { }
}