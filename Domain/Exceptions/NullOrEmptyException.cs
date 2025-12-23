using Domain.Exceptions.BaseExceptions;

namespace Domain.Exceptions;

public class NullOrEmptyException : BadRequestException
{
    public NullOrEmptyException(string propertyName)
        : base($"{propertyName} is required")
    {
    }
}