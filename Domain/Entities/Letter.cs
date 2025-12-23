
using Domain.Common;
using Domain.Enums;
using Domain.EntityPropertyConfigurations;
using Domain.Exceptions;
using Domain.Exceptions.BaseExceptions;
namespace Domain.Entities
{
    public class Letter : AuditableEntity
    {
        public int Id { get; private set; }
        public long LetterNumber { get; private set; }
        public string Subject { get; private set; }
        public string Body { get; private set; }
        public string File { get; private set; }
        public LetterType LetterType { get; private set; }
        public virtual AppUser Sender { get; private set; }
        public int SenderId { get; private set; }
        public virtual ICollection<Letter> Replies { get; private set; } = new List<Letter>();        /// <summary>
        public int? ParentLetterId { get; private set; }
        public virtual Letter ParentLetter { get; private set; }
        private readonly List<LetterRecipient> _recipients = new();
        public virtual IReadOnlyCollection<LetterRecipient> Recipients => _recipients.AsReadOnly();
        private Letter() { }
        public Letter(long letterNumber, string subject, string body, int senderId, string file, LetterType type, int? parentId = null)
        {
            LetterNumber = ValidateLetterNumber(letterNumber);
            Subject = ValidateSubject(subject);
            Body = ValidateBody(body);
            File = file;
            SenderId = senderId;
            LetterType = type;
            ParentLetterId = parentId;
        }
        public void AddRecipient(LetterRecipient recipient, int currentUserId, bool forward)
        {
            if (recipient == null) throw new NullOrEmptyException(nameof(recipient));
            if (this.LetterType == LetterType.Private && forward)
            {
                throw new PrivateLetterForwardException();
            }
            if (recipient.RecipientId == currentUserId)
            {
                throw new SelfForwardingNotAllowedException();
            }
            if (Recipients.Any(r => r.RecipientId == recipient.RecipientId))
            {
                throw new DuplicateRecipientException(recipient.RecipientId);
            }

            _recipients.Add(recipient);
        }
        public void AttachFile(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new NullOrEmptyException(nameof(fileName));

            File = fileName;
        }
        public void MarkAsReadByRecipient(int recipientId)
        {
            var recipient = Recipients.FirstOrDefault(r => r.RecipientId == recipientId);

            if (recipient == null)
                throw new NotFoundException("LetterRecipient" + recipientId.ToString());

            recipient.MarkAsRead();
        }


        public void SetReply(Letter parentLetter)
        {
            if (parentLetter == null) throw new NullOrEmptyException(nameof(parentLetter));
            ParentLetterId = parentLetter.Id;
        }
        private long ValidateLetterNumber(long number)
        {
            if (number < LetterPropertyConfiguration.LetterNumberMinValue) throw new LessThanException(nameof(number), LetterPropertyConfiguration.LetterNumberMinValue);
            return number;
        }


        private string ValidateSubject(string subject)
        {

            if (String.IsNullOrWhiteSpace(subject))
            {
                throw new NullOrEmptyException(nameof(subject));
            }

            if (subject.Length < LetterPropertyConfiguration.SubjectMinLength)
            {
                throw new MinLengthException(nameof(subject), LetterPropertyConfiguration.SubjectMinLength);
            }
            if (subject.Length > LetterPropertyConfiguration.SubjectMaxLength)
            {
                throw new MaxLengthException(nameof(subject), LetterPropertyConfiguration.SubjectMaxLength);
            }
            return subject;
        }
        private string ValidateBody(string body)
        {

            if (String.IsNullOrWhiteSpace(body))
            {
                throw new NullOrEmptyException(nameof(body));
            }

            if (body.Length < LetterPropertyConfiguration.BodyMinLength)
            {
                throw new MinLengthException(nameof(body), LetterPropertyConfiguration.BodyMinLength);
            }
            return body;
        }























































    }
}
