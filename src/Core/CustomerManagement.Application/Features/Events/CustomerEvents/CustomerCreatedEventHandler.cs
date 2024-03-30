using MediatR;

namespace CustomerManagement.Application.Features.Events.CustomerEvents;

public class CustomerCreatedEventHandler : INotificationHandler<CustomerCreatedEvent>
{
    public async Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
    {
        if (notification != null)
            Console.WriteLine($"New customer created: {notification.Customer.FirstName} {notification.Customer.LastName}");
        await Task.CompletedTask;
    }
}
