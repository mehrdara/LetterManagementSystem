using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Repositories
{
    public interface ILetterRecipientRepository : IGenericRepository<LetterRecipient>
    {

        Task Update(LetterRecipient entity);
    }
}