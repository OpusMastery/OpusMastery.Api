using System.Net;

namespace OpusMastery.Exceptions.Abstractions;

public abstract class ApplicationExceptionBase : Exception
{
    public abstract HttpStatusCode StatusCode { get; }
    public string UserMessage { get; }

    protected ApplicationExceptionBase(string userMessage, string? systemMessage = null, Exception? innerException = null) : base(systemMessage, innerException)
    {
        UserMessage = userMessage;
    }
}