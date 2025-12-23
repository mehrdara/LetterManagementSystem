using Domain.Common;
using Domain.Exceptions;

namespace Domain.Entities
{
    public class LetterRecipient : AuditableEntity
    {
        public int Id { get; set; }
        public int LetterId { get; private set; }
        public virtual Letter Letter { get; private set; }

        public int RecipientId { get; private set; }
        public virtual AppUser Recipient { get; private set; }

        public int? ForwardedByUserId { get; private set; }
        public virtual AppUser ForwarderUser { get; private set; }

        public bool IsRead { get; private set; }
        public DateTime? ReadAt { get; private set; }

        private LetterRecipient() { }
        public LetterRecipient(int recipientId, int? forwardedByUserId = null)
        {
            if (recipientId <= 0)
                throw new InvalidIdException(recipientId);
            ForwardedByUserId = forwardedByUserId;
            RecipientId = recipientId;
            IsRead = false;
            ReadAt = null;
        }
        public void MarkAsRead()
        {
            if (IsRead) return;

            IsRead = true;
            ReadAt = DateTime.UtcNow;

        }
    }
}