using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CustomerManagement.Domain.Entities;

namespace CustomerManagement.Persistence.Configurations.EntityTypes;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers", "dbo");

        builder.HasKey(ca => ca.Id);


        builder.OwnsOne(own => own.FirstName);
        builder.OwnsOne(own => own.LastName);
        builder.OwnsOne(own => own.Email);
        builder.OwnsOne(own => own.DateOfBirth);
        builder.OwnsOne(own => own.PhoneNumber);
        builder.OwnsOne(own => own.BankAccountNumber);

    }
}

