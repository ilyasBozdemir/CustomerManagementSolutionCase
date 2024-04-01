using CustomerManagement.Domain.ValueObjects;

namespace CustomerManagement.TDD.Tests.Unit;

public class PhoneNumberTests
{
    [Fact]
    public void PhoneNumber_Should_Be_Valid()
    {
        // Arrange
        var validPhoneNumber = "+905553331122";

        // Act
        var phoneNumber = new PhoneNumber(validPhoneNumber);

        // Assert
        Assert.Equal(validPhoneNumber, phoneNumber.Value);
    }

    //[Theory]
    [InlineData("123")]
    [InlineData("12345901")]
    [InlineData("12s4567890")]
    [InlineData("")]
    public void PhoneNumber_Should_Be_InValid(string invalidPhoneNumber)
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new PhoneNumber(invalidPhoneNumber));
    }
}
