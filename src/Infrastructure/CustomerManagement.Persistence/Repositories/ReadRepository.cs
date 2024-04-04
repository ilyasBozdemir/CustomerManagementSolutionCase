using CustomerManagement.Domain.Extensions;
using CustomerManagement.Domain.Seedwork;
using CustomerManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CustomerManagement.Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;
    public DbSet<T> Table => _context.Set<T>();

    public ReadRepository(AppDbContext context)
    {
        _context = context;
    }

    public IQueryable<T> GetAll(bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        return query;
    }

    public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
    {
        return await Table.AnyAsync(predicate);
    }


    public async Task<T> GetByIdAsync(Guid id, bool tracking = true)
    //=> await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
    //=> await Table.FindAsync(Guid.Parse(id));
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = Table.AsNoTracking();
        return await query.FirstOrDefaultAsync(data => data.Id == id);
    }

    public async Task<Paginate<T>> GetPaginatedAsync(Expression<Func<T, bool>> filter, int pageIndex, int pageSize, bool tracking = true)
    {
        var query = Table.Where(filter);

        if (!tracking)
            query = query.AsNoTracking();

        return await query.PaginateAsync(pageIndex, pageSize);
    }

    public async Task<Paginate<T>> GetPaginatedAsync(int pageIndex, int pageSize, bool tracking = true)
    {
        var query = Table.AsQueryable();

        if (!tracking)
            query = query.AsNoTracking();

        return await query.PaginateAsync(pageIndex, pageSize);
    }

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = Table.AsNoTracking();
        return await query.FirstOrDefaultAsync(method);
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Table.Where(method);
        if (!tracking)
            query = query.AsNoTracking();
        return query;
    }
}
