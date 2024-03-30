using CustomerManagement.Domain.Entities;
using MediatR;

namespace CustomerManagement.Application.Features.Events.CustomerEvents;

public class CustomerUpdatedEvent : INotification
{
    public Customer Customer { get; }

    public CustomerUpdatedEvent(Customer customer)
    {
        Customer = customer;
    }
}
