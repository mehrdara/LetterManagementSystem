using Domain.Exceptions.BaseExceptions;

namespace Domain.Exceptions;

public class LengthException:BadRequestException
{
    public LengthException(string propertyName,int length) : base($"Allowed length for {propertyName} is: {length}")
    {
    }
}