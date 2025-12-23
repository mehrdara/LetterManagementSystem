using Application.Interfaces;
using Application.Repositories;
using Infrastructure.Persistence.Data;


namespace Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        public ILetterRepository Letter { get; private set; }
        public IUserRepository User { get; private set; }
        public ILetterRecipientRepository LetterRecipient { get; private set; }
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Letter = new LetterRepository(_db);
            User = new UserRepository(_db);
            LetterRecipient = new LetterRecipientRepository(db);
        }

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            await _db.SaveChangesAsync(cancellationToken);
        }

    }
}