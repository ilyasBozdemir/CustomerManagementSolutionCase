using CustomerManagement.Application.Features.DTOs;
using CustomerManagement.Application.Features.Queries.GetCustomer;
using CustomerManagement.Application.Features.Utils.Filters;
using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Seedwork;
using MediatR;

namespace CustomerManagement.Application.Features.Queries.GetCustomers;

public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQueryRequest, GetCustomersQueryResponse>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;
    public GetCustomersQueryHandler(IUnitOfWork unitOfWork, IMediator mediator)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
    }

    public async Task<GetCustomersQueryResponse> Handle(GetCustomersQueryRequest request, CancellationToken cancellationToken)
    {

        try
        {
            int page = request.CurrentPage ??= 1;
            int pageSize = request.PageSize ??= 10;

            var customerReadRepository = _unitOfWork.GetReadRepository<Customer>();

            var customerQueryList = customerReadRepository.GetAll();

            if (request.Filters != null)
                foreach (var filter in request.Filters)
                    customerQueryList = FilterItem.ApplyFilter(customerQueryList, filter);
                

            if (request.Sortings != null)
                foreach (var sorting in request.Sortings)
                    customerQueryList = sorting.ApplySorting(customerQueryList);
                
            
            int totalCount = customerQueryList.Count();
            int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var pagedCustomerList = customerQueryList
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var pagination = new Paginate<CustomerDTO>
            {
                PageSize = pageSize,
                CurrentPageIndex = page,
                Count = totalCount,
                Pages = totalPages,
                Items = pagedCustomerList.Select(MapToDTO).ToList() 
            };

            var customerList = new GetCustomersQueryResponse()
            {
                Errors = Array.Empty<string>(),
                Pagination = pagination,
                StatusCode = 200,
                Success = true,
            };

            return customerList;

        }
        catch (Exception ex)
        {
            return new GetCustomersQueryResponse()
            {
                Errors = new[] { ex.Message },
                StatusCode = 500,
                Success = false
            };
        }


        throw new NotImplementedException();
    }
    private CustomerDTO MapToDTO(Customer customer)//automapper could also be used.
    {
        return new CustomerDTO
        {
            Id = customer.Id,
            FirstName = customer.FirstName.Value,
            LastName = customer.LastName.Value,
            Email = customer.Email.Value,
            PhoneNumber = customer.PhoneNumber.Value,
            BankAccountNumber = customer.BankAccountNumber.Value,
            DateOfBirth = customer.DateOfBirth.Value,
        };
    }
}
