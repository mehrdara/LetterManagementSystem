using Domain.Exceptions.BaseExceptions;
namespace Domain.Exceptions
{
    public class DuplicateRecipientException : BadRequestException
    {
        public DuplicateRecipientException(int recipientId)
            : base($" you already added {recipientId}") { }
    }
}