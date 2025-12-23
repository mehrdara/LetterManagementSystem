using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Data;

namespace Infrastructure.Persistence.Repositories
{
    public class LetterRecipientRepository : GenericRepository<LetterRecipient>, ILetterRecipientRepository
    {
        private readonly AppDbContext _db;

        public LetterRecipientRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task Update(LetterRecipient entity)
        {
            _db.LetterRecipients.Update(entity);

        }
    }
}

