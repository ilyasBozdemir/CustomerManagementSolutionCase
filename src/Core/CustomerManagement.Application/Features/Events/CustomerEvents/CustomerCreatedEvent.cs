using CustomerManagement.Domain.Entities;
using MediatR;

namespace CustomerManagement.Application.Features.Events.CustomerEvents;

public class CustomerCreatedEvent : INotification
{
    public Customer Customer { get; }

    public CustomerCreatedEvent(Customer customer)
    {
        Customer = customer;
    }
}