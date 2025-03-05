using Microsoft.EntityFrameworkCore;

namespace Common.Pagination;

public static class PaginationExtension
{
    public static async Task<PaginateResult<T>> Paginate<T>(this IQueryable<T> query, IPagination request, CancellationToken cancellationToken)
    {
        var count = await query.CountAsync(cancellationToken);
        
        var result = await query
            .Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken: cancellationToken);
        
        return new PaginateResult<T>
        {
            PageSize = request.PageSize,
            PageIndex = request.PageIndex,
            Count = count,
            Data = result
        };
    }
}