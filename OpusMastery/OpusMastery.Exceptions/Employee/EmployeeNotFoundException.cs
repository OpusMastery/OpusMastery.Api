using System.Net;
using OpusMastery.Exceptions.Abstractions;

namespace OpusMastery.Exceptions.Employee;

public class EmployeeNotFoundException : ApplicationExceptionBase
{
    public override HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public EmployeeNotFoundException(Guid userId) : base($"The employee with userId: {userId} was not found.") { }
}