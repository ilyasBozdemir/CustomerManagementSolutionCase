namespace CustomerManagement.Domain.Seedwork;
public interface IWriteRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    Task<bool> AddAsync(T model);
    Task<bool> AddRangeAsync(List<T> datas);
    Task<bool> Remove(T model);
    Task<bool> RemoveRange(List<T> datas);
    Task<bool> RemoveAsync(string id);
    Task<bool> Update(T model);
    Task<int> SaveAsync();
}