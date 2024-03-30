using MediatR;

namespace CustomerManagement.Application.Features.Queries.GetCustomer;

public class GetCustomerByIdQueryRequest : IRequest<GetCustomerByIdQueryResponse>
{
    public Guid CustomerId { get; set; }
}
