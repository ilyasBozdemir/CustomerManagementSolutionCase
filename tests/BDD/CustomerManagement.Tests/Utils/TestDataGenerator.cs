using CustomerManagement.Domain.Entities;

namespace CustomerManagement.BDD.Tests.Utils;

public static class TestDataGenerator
{
    public static Customer GenerateCustomer()
    {
        return new Customer
        {
            Id = Guid.NewGuid(),
            FirstName = new Domain.ValueObjects.FirstName("John"),
            LastName = new Domain.ValueObjects.LastName("Doe"),
            DateOfBirth = new Domain.ValueObjects.DateOfBirth(new DateTime(1990, 1, 1)),
            PhoneNumber = new Domain.ValueObjects.PhoneNumber("+905554442211"),
            Email = new Domain.ValueObjects.Email("john.doe@example.com"),
            BankAccountNumber = new Domain.ValueObjects.BankAccountNumber("1234567890123456")
        };
    }
}

