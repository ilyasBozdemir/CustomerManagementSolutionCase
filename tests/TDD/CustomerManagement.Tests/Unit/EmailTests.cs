using CustomerManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.TDD.Tests.Unit;

public class EmailTests
{
    [Fact]
    public void Email_Should_Be_Valid()
    {
        // Arrange
        var validEmail = "example@example.com";

        // Act
        var email = new Email(validEmail);

        // Assert
        Assert.Equal(validEmail, email.Value);
    }

    [Theory]
    [InlineData("example@examplecom")]
    [InlineData("exampleexample.com")]
    [InlineData("example@.com")]
    [InlineData("example@")]
    [InlineData("example")]
    public void Email_Should_Be_InValid(string invalidEmail)
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new Email(invalidEmail));
    }
}
