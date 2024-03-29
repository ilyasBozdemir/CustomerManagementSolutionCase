using MediatR;

namespace CustomerManagement.Application.Features.Commands.DeleteCustomer;

public class DeleteCustomerCommandRequest : IRequest<DeleteCustomerCommandResponse>
{
    public Guid CustomerId { get; set; }
}