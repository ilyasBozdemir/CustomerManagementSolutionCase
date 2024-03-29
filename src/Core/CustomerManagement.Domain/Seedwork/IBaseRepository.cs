using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Domain.Seedwork;

public interface IBaseRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
}
