using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Helpers;

public static class QueryExecutor
{
    public static async Task<List<T>> ToListAsyncSafe<T>(IQueryable<T> query, CancellationToken cancellationToken)
    {
        return await query.ToListAsync(cancellationToken);
    }
}