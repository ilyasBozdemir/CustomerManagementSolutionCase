using MediatR;

namespace CustomerManagement.Application.Features.Events.CustomerEvents;


public class CustomerListedEventHandler : INotificationHandler<CustomerListedEvent>
{
    public async Task Handle(CustomerListedEvent notification, CancellationToken cancellationToken)
    {
        if (notification != null)
        {
            Console.WriteLine($"Customer Updated:");

            foreach (var Customer in notification.Customers)
            {
                Console.WriteLine($"FirstName : {Customer.FirstName} LastName : {Customer.LastName}");
            }
        }
           
        await Task.CompletedTask;
    }
}