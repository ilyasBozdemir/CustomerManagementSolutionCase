using MediatR;

namespace CustomerManagement.Application.Features.Events.CustomerEvents;

public class CustomerDeletedEventHandler : INotificationHandler<CustomerDeletedEvent>
{
    public async Task Handle(CustomerDeletedEvent notification, CancellationToken cancellationToken)
    {
        if (notification != null)
            Console.WriteLine($"Customer Deleted: {notification.CustomerId}");
        await Task.CompletedTask;
    }
}