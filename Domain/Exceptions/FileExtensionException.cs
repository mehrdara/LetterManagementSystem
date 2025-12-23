using Domain.Exceptions.BaseExceptions;

namespace Domain.Exceptions;

public class FileExtensionException:BadRequestException
{
    public FileExtensionException(string expectedExtension) : base($"The file extension should be ' {expectedExtension} ' ")
    {
    }
}