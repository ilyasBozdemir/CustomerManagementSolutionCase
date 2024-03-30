using CustomerManagement.Application.Features.DTOs;
using MediatR;

namespace CustomerManagement.Application.Features.Events.CustomerEvents;

public class CustomerFetchedEvent : INotification
{
    public CustomerDTO Customer { get; }

    public CustomerFetchedEvent(CustomerDTO customer)
    {
        Customer = customer;
    }
}
