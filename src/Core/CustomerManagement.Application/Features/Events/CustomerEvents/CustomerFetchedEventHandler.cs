using MediatR;

namespace CustomerManagement.Application.Features.Events.CustomerEvents;


public class CustomerFetchedEventHandler : INotificationHandler<CustomerFetchedEvent>
{
    public async Task Handle(CustomerFetchedEvent notification, CancellationToken cancellationToken)
    {
        if (notification != null)
            Console.WriteLine($"New customer created: {notification.Customer.FirstName} {notification.Customer.LastName}");
        await Task.CompletedTask;
    }
}