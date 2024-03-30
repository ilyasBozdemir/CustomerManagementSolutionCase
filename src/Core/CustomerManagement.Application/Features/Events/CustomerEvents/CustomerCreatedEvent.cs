using CustomerManagement.Application.Features.DTOs;
using MediatR;

namespace CustomerManagement.Application.Features.Events.CustomerEvents;

public class CustomerCreatedEvent : INotification
{
    public CustomerDTO Customer { get; }

    public CustomerCreatedEvent(CustomerDTO customer)
    {
        Customer = customer;
    }
}