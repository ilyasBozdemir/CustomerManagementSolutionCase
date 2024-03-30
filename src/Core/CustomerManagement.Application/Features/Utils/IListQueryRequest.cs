using CustomerManagement.Application.Features.Utils.Filters;
using MediatR;

namespace CustomerManagement.Application.Features.Utils;

public interface IListQueryRequest<TResponse> : IRequest<TResponse>
{
    public int? CurrentPage { get; set; } 
    public byte? PageSize { get; set; } 
    public List<FilterItem>? Filters { get; set; }
    public List<SortingItemOption>? Sortings { get; set; }
}
