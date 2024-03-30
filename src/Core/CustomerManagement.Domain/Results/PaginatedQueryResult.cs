using CustomerManagement.Domain.Seedwork;

namespace CustomerManagement.Domain.Results;

public class PaginatedQueryResult<T> : ActionResult<IList<T>>
{
    public Paginate<T> Pagination { get; set; }

    public PaginatedQueryResult(bool success, int statusCode, Paginate<T> pagination, string[] errors = null)
        : base(success, statusCode, errors)
    {
        Pagination = pagination;
    }

    public PaginatedQueryResult()
    {
        Pagination = new Paginate<T>();
    }
}