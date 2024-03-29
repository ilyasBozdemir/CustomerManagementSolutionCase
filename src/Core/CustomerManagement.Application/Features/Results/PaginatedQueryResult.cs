using CustomerManagement.Application.Features.Wrappers.Paging;

namespace CustomerManagement.Application.Features.Results;

public class PaginatedQueryResult<T> : QueryResult<IList<T>>
{
    public Paginate<T> Pagination { get; set; }

    public PaginatedQueryResult(bool success, int statusCode, IList<T> data, Paginate<T> pagination, string[] errors = null)
        : base(success, statusCode, data, errors)
    {
        Pagination = pagination;
    }

    public PaginatedQueryResult()
    {
        Pagination = new Paginate<T>();
    }
}
