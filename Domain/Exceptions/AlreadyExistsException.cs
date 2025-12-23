using Domain.Exceptions.BaseExceptions;

namespace Domain.Exceptions;

public class AlreadyExistException : BadRequestException
{
    public AlreadyExistException(string propertyName, string propertyValue)
        : base($"{propertyName} \" {propertyValue} \" already exists")
    {
    }
}