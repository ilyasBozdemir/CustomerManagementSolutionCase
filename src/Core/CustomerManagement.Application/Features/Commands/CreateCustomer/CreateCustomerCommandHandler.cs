using MediatR;
using CustomerManagement.Domain.Seedwork;
using CustomerManagement.Domain.Entities;
using CustomerManagement.Application.Features.Events.CustomerEvents;
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
             
                await _mediator.Publish(new CustomerCreatedEvent(newCustomer));

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
}

