using CustomerManagement.Domain.Entities;

namespace CustomerManagement.TDD.Tests.Unit;

public class CustomerTests
{
    [Fact]
    public void Customer_Should_Have_Default_Properties()
    {
        // Arrange
        var customer = new Customer();

        // Assert
        Assert.NotNull(customer);
        Assert.Equal(default(Guid), customer.Id);
        Assert.Null(customer.FirstName);
        Assert.Null(customer.LastName);
        Assert.Null(customer.DateOfBirth);
        Assert.Null(customer.PhoneNumber);
        Assert.Null(customer.Email);
        Assert.Null(customer.BankAccountNumber);
    }
}