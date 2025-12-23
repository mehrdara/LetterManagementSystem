using Application.Repositories;

namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        ILetterRepository Letter { get; }
        IUserRepository User { get; }
        ILetterRecipientRepository LetterRecipient { get; }
        Task SaveAsync(CancellationToken cancellationToken = default);
    }
}
