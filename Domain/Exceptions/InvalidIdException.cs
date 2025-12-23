using Domain.Exceptions.BaseExceptions;

namespace Domain.Exceptions;

public class InvalidIdException : BadRequestException
{
    public InvalidIdException(int id)
        : base($"{id} is invalid  ")
    {
    }
}