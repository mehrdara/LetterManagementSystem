using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Data;

namespace Infrastructure.Persistence.Repositories
{
    public class LetterRepository : GenericRepository<Letter>, ILetterRepository
    {
        private readonly AppDbContext _db;

        public LetterRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public
        async Task Update(Letter entity)
        {
            _db.Letters.Update(entity);

        }
    }
}