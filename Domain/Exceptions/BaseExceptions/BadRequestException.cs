using System.Net;

namespace Domain.Exceptions.BaseExceptions;

public class BadRequestException:AppExceptionBase
{
    public BadRequestException(string message) : base(message, HttpStatusCode.BadRequest)
    {
    }
}