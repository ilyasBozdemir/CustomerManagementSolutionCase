using CustomerManagement.Application.Features.Utils;
using CustomerManagement.Application.Features.Utils.Filters;

namespace CustomerManagement.Application.Features.Queries.GetCustomers;

public class GetCustomersQueryRequest : IListQueryRequest<GetCustomersQueryResponse>
{
    public int? CurrentPage { get; set; } = 1;
    public byte? PageSize { get; set; } = 10;
    public List<FilterItem>? Filters { get; set; }
    public List<SortingItemOption>? Sortings { get; set; }
}
