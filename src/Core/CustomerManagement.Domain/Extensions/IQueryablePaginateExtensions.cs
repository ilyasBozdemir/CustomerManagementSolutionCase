using CustomerManagement.Domain.Seedwork;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Domain.Extensions;

public static class IQueryablePaginateExtensions
{
    public static async Task<Paginate<T>> PaginateAsync<T>(
        this IQueryable<T> source,
        int index,
        int size,
        CancellationToken cancellationToken = default
        )
    {
        int count = await source.CountAsync(cancellationToken);
        List<T> items = await source
            .Skip(index * size)
            .Take(size)
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);

        return new()
        {
            CurrentPageIndex = index,
            Count = count,
            Items = items,
            PageSize = size,
            Pages = (int)Math.Ceiling(count / (double)size),
        };
    }


    public static Paginate<T> Paginate<T>(this IQueryable<T> source, int index, int size)
    {

        int count = source.Count();

        List<T> items = source
            .Skip(index * size)
            .Take(size)
            .ToList();

        return new()
        {
            CurrentPageIndex = index,
            Count = count,
            Items = items,
            PageSize = size,
            Pages = (int)Math.Ceiling(count / (double)size),
        };
    }
}

