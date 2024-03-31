using MediatR;
using CustomerManagement.Domain.Seedwork;
using CustomerManagement.Domain.Entities;
using CustomerManagement.Application.Features.Events.CustomerEvents;
using CustomerManagement.Application.Features.DTOs;
namespace CustomerManagement.Application.Features.Commands.CreateCustomer;
public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommandRequest, CreateCustomerCommandResponse>
{
    private readonly IUnitOfWork  _unitOfWork;
    private readonly IMediator _mediator;
    public CreateCustomerCommandHandler(IUnitOfWork unitOfWork, IMediator mediator)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
    }
    public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var newCustomer = new Customer
            {
                FirstName = new Domain.ValueObjects.FirstName(request.FirstName),
                LastName = new Domain.ValueObjects.LastName(request.LastName),
                DateOfBirth = new Domain.ValueObjects.DateOfBirth(request.DateOfBirth),
                PhoneNumber = new Domain.ValueObjects.PhoneNumber(request.PhoneNumber),
                Email = new Domain.ValueObjects.Email(request.Email),
                BankAccountNumber = new Domain.ValueObjects.BankAccountNumber(request.BankAccountNumber)
            };

            var customerRepository = _unitOfWork.GetWriteRepository<Customer>();

            var addedState = customerRepository.AddAsync(newCustomer);
            if (addedState.Result)
            {
             
                await _mediator.Publish(new CustomerCreatedEvent(MapToDTO(newCustomer)));

                return new CreateCustomerCommandResponse
                {
                    Success = addedState.Result,
                    StatusCode = 200,
                    Data = newCustomer,
                    Errors = Array.Empty<string>()
                };
              
            }
            else
                return new CreateCustomerCommandResponse
                {
                    Success = addedState.Result,
                    StatusCode = 409,
                    Errors = new[] { "Customer with the same data already exists." }
                };
        }
        catch (Exception ex)
        {
            return new CreateCustomerCommandResponse
            {
                Success = false,
                StatusCode = 500, 
                Errors = new[] { ex.Message }
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