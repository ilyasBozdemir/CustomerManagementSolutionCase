using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CustomerManagement.Application;

public static class ServiceRegistration
{
    public static void AddApplicationRegistration(this IServiceCollection services)
    {
        // MediatR servislerini kaydet
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}
