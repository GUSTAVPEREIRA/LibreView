using Core.Pagination;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Pagination;

public static class QueryableExtension
{
    public static async Task<PagedResult<T>> GetPaged<T>(this IQueryable<T> query,
        int page, int pageSize) where T : class
    {
        if (pageSize < 1 || page < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size is mandatory be greater than 0");
        }

        var result = new PagedResult<T>
        {
            CurrentPage = page,
            PageSize = pageSize,
            RowCount = await query.CountAsync()
        };

        var pageCount = (double)result.RowCount / pageSize;
        result.PageCount = (int)Math.Ceiling(pageCount);

        var skip = (page - 1) * pageSize;
        result.Results = await query.Skip(skip).Take(pageSize).ToListAsync();

        return result;
    }
}