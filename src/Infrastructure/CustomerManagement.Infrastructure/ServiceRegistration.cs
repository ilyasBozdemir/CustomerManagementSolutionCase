using CustomerManagement.Domain.Seedwork;
using CustomerManagement.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerManagement.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<ILoggerService, LoggerService>();

    }
}
