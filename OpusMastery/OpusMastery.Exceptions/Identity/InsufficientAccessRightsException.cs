using System.Net;
using OpusMastery.Exceptions.Abstractions;

namespace OpusMastery.Exceptions.Identity;

public class InsufficientAccessRightsException : ApplicationExceptionBase
{
    public override HttpStatusCode StatusCode => HttpStatusCode.Forbidden;

    public InsufficientAccessRightsException(string userMessage) : base(userMessage) { }
}