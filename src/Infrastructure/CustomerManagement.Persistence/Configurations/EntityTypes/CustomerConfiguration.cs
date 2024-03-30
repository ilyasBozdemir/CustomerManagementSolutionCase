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


        builder.OwnsOne(own => own.FirstName)
            .Property(x => x.Value) 
            .HasColumnName("FirstName"); 
        builder.OwnsOne(own => own.LastName)
            .Property(x => x.Value)
            .HasColumnName("LastName");
        builder.OwnsOne(own => own.Email)
            .Property(x => x.Value)
            .HasColumnName("Email");
        builder.OwnsOne(own => own.DateOfBirth)
            .Property(x => x.Value)
            .HasColumnName("DateOfBirth");
        builder.OwnsOne(own => own.PhoneNumber)
            .Property(x => x.Value)
            .HasColumnName("PhoneNumber");
        builder.OwnsOne(own => own.BankAccountNumber)
            .Property(x => x.Value)
            .HasColumnName("BankAccountNumber");
    }
}