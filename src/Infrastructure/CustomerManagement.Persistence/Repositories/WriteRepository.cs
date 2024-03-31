using CustomerManagement.Domain.Seedwork;
using CustomerManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CustomerManagement.Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T>
    where T : BaseEntity
{
    private readonly AppDbContext _context;

    public WriteRepository(AppDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public async Task<bool> AddAsync(T model)
    {
        await Table.AddAsync(model);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AddRangeAsync(List<T> datas)
    {
        await Table.AddRangeAsync(datas);
        return true;
    }

    public async Task<bool> Remove(T model)
    {
        if (model is ISoftDeletable softDeletable)
        {
            softDeletable.IsDeleted = true;
            softDeletable.DeletedDate = DateTime.UtcNow;
            EntityEntry<T> entityEntry = Table.Update(model);
            await _context.SaveChangesAsync();
            return entityEntry.State == EntityState.Modified;
        }
        else
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            await _context.SaveChangesAsync();
            return entityEntry.State == EntityState.Deleted;
        }
    }

    public async Task<bool> RemoveRange(List<T> datas)
    {
        foreach (var model in datas)
        {
            if (model is ISoftDeletable softDeletable)
            {
                softDeletable.IsDeleted = true;
                softDeletable.DeletedDate = DateTime.UtcNow;
                Table.Update(model);
                await _context.SaveChangesAsync();
            }
            else
            {
                Table.Remove(model);
                await _context.SaveChangesAsync();
            }
        }

        return true;
    }

    public async Task<bool> RemoveAsync(string id)
    {
        T model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        await Remove(model);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(T model)
    {
        EntityEntry entityEntry = Table.Update(model);
        await _context.SaveChangesAsync();
        return entityEntry.State == EntityState.Modified;
    }

    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
}
