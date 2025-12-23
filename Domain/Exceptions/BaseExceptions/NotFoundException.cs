using System.Net;

namespace Domain.Exceptions.BaseExceptions;

public class NotFoundException:AppExceptionBase
{
    public NotFoundException(string PropertyName) : base($"{PropertyName} was not found", HttpStatusCode.NotFound)
    {
        
    }
}