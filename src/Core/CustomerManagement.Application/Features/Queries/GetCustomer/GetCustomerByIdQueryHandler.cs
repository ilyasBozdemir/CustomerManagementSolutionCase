using CustomerManagement.Application.Features.Commands.DeleteCustomer;
using CustomerManagement.Application.Features.DTOs;
using CustomerManagement.Application.Features.Events.CustomerEvents;
using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Seedwork;
using MediatR;

namespace CustomerManagement.Application.Features.Queries.GetCustomer;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQueryRequest, GetCustomerByIdQueryResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;
    public GetCustomerByIdQueryHandler(IUnitOfWork unitOfWork, IMediator mediator)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
    }

    public async Task<GetCustomerByIdQueryResponse> Handle(GetCustomerByIdQueryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var customerReadRepository = _unitOfWork.GetReadRepository<Customer>();

            var customer = await customerReadRepository.GetByIdAsync(request.CustomerId.ToString());


            //return new DeleteCustomerCommandResponse(false, 404, null, new[] { "Customer not found." });

            if (customer != null)
            {

                await _mediator.Publish(new CustomerFetchedEvent(MapToDTO(customer)));

                return new GetCustomerByIdQueryResponse()
                {
                    Data = MapToDTO(customer),
                    StatusCode = 200,
                    Success = true
                };
            }
            else
            {
                return new GetCustomerByIdQueryResponse()
                {
                    Errors = new[] { "Customer not found." },
                    StatusCode = 404,
                    Success = false
                };
            }
        }
        catch (Exception ex)
        {
            return new GetCustomerByIdQueryResponse() 
            {
                Errors = new[] { ex.Message },
                StatusCode = 500,
                Success = false
            };
        }
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
