using Domain.Exceptions.BaseExceptions;

namespace Domain.Exceptions;

public class FileSizeException:BadRequestException
{
    public FileSizeException(long maxSize) : base($"The maximum size of file is : ' {maxSize} '")
    {
    }
}