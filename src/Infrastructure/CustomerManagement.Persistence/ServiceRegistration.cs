using CustomerManagement.Domain.Seedwork;
using CustomerManagement.Persistence.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerManagement.Persistence;

public static class ServiceRegistration
{
    public static async Task AddPersistenceRegistration(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
