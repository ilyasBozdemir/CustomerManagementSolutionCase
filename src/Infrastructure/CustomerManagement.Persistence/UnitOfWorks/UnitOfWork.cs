using CustomerManagement.Domain.Seedwork;
using CustomerManagement.Persistence.Contexts;
using CustomerManagement.Persistence.Repositories;

namespace CustomerManagement.Persistence.UnitOfWorks;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AppDbContext _context;
    
    public UnitOfWork(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public IReadRepository<T> GetReadRepository<T>() where T : BaseEntity
    {
        return new ReadRepository<T>(_context);
    }

    public IWriteRepository<T> GetWriteRepository<T>() where T : BaseEntity
    {
        return new WriteRepository<T>(_context);
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
