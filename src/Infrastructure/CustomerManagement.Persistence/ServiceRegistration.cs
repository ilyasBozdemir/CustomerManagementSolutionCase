using CustomerManagement.Domain.Seedwork;
using CustomerManagement.Persistence.Contexts;
using CustomerManagement.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerManagement.Persistence;

public static class ServiceRegistration
{
    public static async Task AddPersistenceRegistration(this IServiceCollection services)
    {
        services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer(@"Server=DESKTOP-R4UP5K6\SQLEXPRESS;Database=AppDb;Integrated Security=True;TrustServerCertificate=True;",
                    sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(3),
                        errorNumbersToAdd: null);
                    })
                    .EnableSensitiveDataLogging()
                );


        services.AddScoped<IUnitOfWork, UnitOfWork>();
    
    }
}
