using MediatR;
using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Seedwork;

namespace CustomerManagement.Application.Features.Commands.UpdateCustomer;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var customerReadRepository = _unitOfWork.GetReadRepository<Customer>();

            var existingCustomer = await customerReadRepository.GetByIdAsync(request.CustomerId.ToString());
            if (existingCustomer == null)
                return new UpdateCustomerCommandResponse(false, 404, null, new[] { "Customer not found." });
            

            existingCustomer.FirstName = new Domain.ValueObjects.FirstName(request.FirstName);
            existingCustomer.LastName = new Domain.ValueObjects.LastName(request.FirstName);
            existingCustomer.DateOfBirth = new Domain.ValueObjects.DateOfBirth(request.DateOfBirth);
            existingCustomer.PhoneNumber = new Domain.ValueObjects.PhoneNumber(request.PhoneNumber);
            existingCustomer.Email = new Domain.ValueObjects.Email(request.Email);
            existingCustomer.BankAccountNumber = new Domain.ValueObjects.BankAccountNumber(request.BankAccountNumber);

            var customerRepository = _unitOfWork.GetWriteRepository<Customer>();
            customerRepository.Update(existingCustomer);

            return new UpdateCustomerCommandResponse(true, 200, existingCustomer);
        }
        catch (Exception ex)
        {
            return new UpdateCustomerCommandResponse(false, 500, null, new[] { ex.Message });
        }
    }
}
