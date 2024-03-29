using MediatR;
using CustomerManagement.Domain.Seedwork;
using CustomerManagement.Domain.Entities;
namespace CustomerManagement.Application.Features.Commands.CreateCustomer;
public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
{
    private readonly IUnitOfWork  _unitOfWork;
    public CreateCustomerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var customer = new Customer
            {
                FirstName = new Domain.ValueObjects.FirstName(request.FirstName),
                LastName = new Domain.ValueObjects.LastName(request.LastName),
                DateOfBirth = new Domain.ValueObjects.DateOfBirth(request.DateOfBirth),
                PhoneNumber = new Domain.ValueObjects.PhoneNumber(request.PhoneNumber),
                Email = new Domain.ValueObjects.Email(request.Email),
                BankAccountNumber = new Domain.ValueObjects.BankAccountNumber(request.BankAccountNumber)
            };

            var customerRepository = _unitOfWork.GetWriteRepository<Customer>();

            var addedState = customerRepository.AddAsync(customer);

            if (addedState.Result)
                return new CreateCustomerCommandResponse
                {
                    Success = addedState.Result,
                    StatusCode = 200,
                    Data = customer,
                    Errors = Array.Empty<string>()
                };
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

