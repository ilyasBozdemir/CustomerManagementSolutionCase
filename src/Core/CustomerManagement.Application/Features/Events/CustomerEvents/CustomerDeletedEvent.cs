using MediatR;

namespace CustomerManagement.Application.Features.Events.CustomerEvents;

public class CustomerDeletedEvent : INotification
{
    public Guid CustomerId { get; }

    public CustomerDeletedEvent(Guid customerId)
    {
        CustomerId = customerId;
    }
}
