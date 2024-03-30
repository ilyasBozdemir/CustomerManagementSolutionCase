using MediatR;

namespace CustomerManagement.Application.Features.Events.CustomerEvents;


public class CustomerUpdatedEventHandled : INotificationHandler<CustomerUpdatedEvent>
{
    public async Task Handle(CustomerUpdatedEvent notification, CancellationToken cancellationToken)
    {
        if (notification != null)
            Console.WriteLine($"Customer Updated: {notification.Customer.FirstName.Value} {notification.Customer.LastName.Value}");
        await Task.CompletedTask;
    }
}