using Domain.Entities;
using Application.Interfaces;

namespace Application.Repositories
{
    public interface ILetterRepository : IGenericRepository<Letter>
    {

        Task Update(Letter entity);

    }
}
