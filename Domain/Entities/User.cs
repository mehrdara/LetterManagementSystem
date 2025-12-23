using Domain.Common;
using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Domain.EntityPropertyConfigurations;

namespace Domain.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OrganizationMail
        {
            get => base.Email;
            set => base.Email = value;
        }
        public virtual ICollection<Letter> SentLetters { get; set; } = new List<Letter>();
        public virtual ICollection<LetterRecipient> ReceivedLetters { get; set; } = new List<LetterRecipient>();
        public AppUser() { }
        public AppUser(string username, string firstName, string lastName, string email)
        {
            SetUsername(username);
            SetFirstName(firstName);
            SetLastName(lastName);
            OrganizationMail = email;
        }
        private string ValidateUsername(string username)
        {
            if (String.IsNullOrWhiteSpace(username))
            {
                throw new NullOrEmptyException(nameof(username));
            }

            if (username.Length < UserPropertyConfiguration.UsernameMinLength)
            {
                throw new MinLengthException(nameof(username), UserPropertyConfiguration.UsernameMinLength);
            }

            if (username.Length > UserPropertyConfiguration.UsernameMaxLength)
            {
                throw new MaxLengthException(nameof(username), UserPropertyConfiguration.UsernameMaxLength);
            }

            return username;
        }

        private string ValidateFirstName(string firstName)
        {
            if (String.IsNullOrWhiteSpace(firstName))
            {
                throw new NullOrEmptyException(nameof(firstName));
            }

            if (firstName.Length < UserPropertyConfiguration.FirstNameMinLength)
            {
                throw new MinLengthException(nameof(firstName), UserPropertyConfiguration.FirstNameMinLength);
            }

            if (firstName.Length > UserPropertyConfiguration.FirstNameMaxLength)
            {
                throw new MaxLengthException(nameof(firstName), UserPropertyConfiguration.FirstNameMaxLength);
            }

            return firstName;
        }
        private string ValidateLastName(string lastName)
        {
            if (String.IsNullOrWhiteSpace(lastName))
            {
                throw new NullOrEmptyException(nameof(lastName));
            }

            if (lastName.Length < UserPropertyConfiguration.LastNameMinLength)
            {
                throw new MinLengthException(nameof(lastName), UserPropertyConfiguration.LastNameMinLength);
            }

            if (lastName.Length > UserPropertyConfiguration.LastNameMaxLength)
            {
                throw new MaxLengthException(nameof(lastName), UserPropertyConfiguration.LastNameMaxLength);
            }

            return lastName;
        }
        internal void SetUsername(string username)
        {
            UserName = ValidateUsername(username);
        }
        internal void SetFirstName(string firstName)
        {
            FirstName = ValidateFirstName(firstName);
        }
        internal void SetLastName(string lastName)
        {
            LastName = ValidateLastName(lastName);
        }



    }
}

