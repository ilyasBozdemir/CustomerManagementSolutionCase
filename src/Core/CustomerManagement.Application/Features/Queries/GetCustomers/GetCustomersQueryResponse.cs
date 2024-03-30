using CustomerManagement.Application.Features.DTOs;
using CustomerManagement.Domain.Results;

namespace CustomerManagement.Application.Features.Queries.GetCustomers;

public class GetCustomersQueryResponse:PaginatedQueryResult<CustomerDTO>
{

}
