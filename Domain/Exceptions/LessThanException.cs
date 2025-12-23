using Domain.Exceptions.BaseExceptions;

namespace Domain.Exceptions;

public class LessThanException:BadRequestException
{
    public LessThanException(string propertyName,long compareValue):base($"The value of ' {propertyName} ' can not be less than ' {compareValue} ' .")
    {
        
    }
}