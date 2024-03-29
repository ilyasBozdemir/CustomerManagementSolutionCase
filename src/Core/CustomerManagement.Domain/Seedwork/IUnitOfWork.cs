namespace CustomerManagement.Domain.Seedwork;
public interface IUnitOfWork : IDisposable
{
    IReadRepository<T> GetReadRepository<T>() where T : BaseEntity;
    IWriteRepository<T> GetWriteRepository<T>() where T : BaseEntity;
    Task<int> SaveAsync();
}