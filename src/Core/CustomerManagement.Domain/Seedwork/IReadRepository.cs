using System.Linq.Expressions;

namespace CustomerManagement.Domain.Seedwork;

public interface IReadRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll(bool tracking = true);
    IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
    Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
    Task<T> GetByIdAsync(string id, bool tracking = true);


    Task<Paginate<T>> GetPaginatedAsync(int pageIndex, int pageSize, bool tracking = true);
    Task<Paginate<T>> GetPaginatedAsync(Expression<Func<T, bool>> filter, int pageIndex, int pageSize, bool tracking = true);
}