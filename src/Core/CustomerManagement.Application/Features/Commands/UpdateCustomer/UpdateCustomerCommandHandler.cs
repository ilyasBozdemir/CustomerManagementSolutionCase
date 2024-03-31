using MediatR;
using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Seedwork;
using CustomerManagement.Application.Features.Events.CustomerEvents;
using CustomerManagement.Application.Features.DTOs;

namespace CustomerManagement.Application.Features.Commands.UpdateCustomer;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommandRequest, UpdateCustomerCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;
    public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork, IMediator mediator)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
    }

    public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var customerReadRepository = _unitOfWork.GetReadRepository<Customer>();

            var existingCustomer = await customerReadRepository.GetByIdAsync(request.CustomerId.ToString());
            if (existingCustomer == null)
                return new UpdateCustomerCommandResponse(false, 404, null, new[] { "Customer not found." });
            

            existingCustomer.FirstName = new Domain.ValueObjects.FirstName(request.FirstName);
            existingCustomer.LastName = new Domain.ValueObjects.LastName(request.LastName);
            existingCustomer.DateOfBirth = new Domain.ValueObjects.DateOfBirth(request.DateOfBirth);
            existingCustomer.PhoneNumber = new Domain.ValueObjects.PhoneNumber(request.PhoneNumber);
            existingCustomer.Email = new Domain.ValueObjects.Email(request.Email);
            existingCustomer.BankAccountNumber = new Domain.ValueObjects.BankAccountNumber(request.BankAccountNumber);

            var customerWriteRepository = _unitOfWork.GetWriteRepository<Customer>();
            customerWriteRepository.Update(existingCustomer);
            await _mediator.Publish(new CustomerUpdatedEvent(MapToDTO(existingCustomer)));
            return new UpdateCustomerCommandResponse(true, 200, existingCustomer);
        }
        catch (Exception ex)
        {
            return new UpdateCustomerCommandResponse(false, 500, null, new[] { ex.Message });
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
