using MediatR;
using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Seedwork;
using CustomerManagement.Application.Features.Events.CustomerEvents;

namespace CustomerManagement.Application.Features.Commands.DeleteCustomer;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommandRequest, DeleteCustomerCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;
    public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork, IMediator mediator)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
    }

    public async Task<DeleteCustomerCommandResponse> Handle(DeleteCustomerCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var customerReadRepository = _unitOfWork.GetReadRepository<Customer>();
            var existingCustomer = await customerReadRepository.GetByIdAsync(request.CustomerId.ToString());

            if (existingCustomer == null)
                return new DeleteCustomerCommandResponse(false, 404, null, new[] { "Customer not found." });

            var customerWriteRepository = _unitOfWork.GetWriteRepository<Customer>();

            await customerWriteRepository.RemoveAsync(existingCustomer.Id.ToString());

            await _mediator.Publish(new CustomerDeletedEvent(existingCustomer.Id));
            return new DeleteCustomerCommandResponse(true, 200, existingCustomer);
           
        }
        catch (Exception ex)
        {
            return new DeleteCustomerCommandResponse(false, 500, null, new[] { ex.Message });
        }
    }

   
}
