using CustomerManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Persistence.Design;

public class DesignTimeAppDbContext : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        optionsBuilder.UseSqlServer(@"Server=DESKTOP-R4UP5K6\SQLEXPRESS;Database=AppDb;Integrated Security=True;TrustServerCertificate=True;");
        return new AppDbContext(optionsBuilder.Options);
    }
}

