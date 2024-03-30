using CustomerManagement.Application.Features.DTOs;
using MediatR;

namespace CustomerManagement.Application.Features.Events.CustomerEvents;

public class CustomerListedEvent : INotification
{
    public IEnumerable<CustomerDTO> Customers { get; }
    public CustomerListedEvent(IEnumerable<CustomerDTO> customers)
    {
        Customers = customers;
    }
}
