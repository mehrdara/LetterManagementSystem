using System.Linq.Expressions;

namespace Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {

        Task<List<TProjected>> ToListAsync<TProjected>(IQueryable<TProjected> query, CancellationToken ct); IQueryable<T> GetAll(
                    Expression<Func<T, bool>>? filter = null,
                    string? includeProperties = null,
                    bool tracked = false);

        Task<T?> GetAsync(
            Expression<Func<T, bool>> filter,
            string? includeProperties = null,
            bool tracked = false,
            CancellationToken cancellationToken = default);

        Task AddAsync(T entity, CancellationToken cancellationToken = default);

        Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

    }
}