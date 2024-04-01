using CustomerManagement.Application.Features.Commands.CreateCustomer;
using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Seedwork;
using CustomerManagement.Domain.ValueObjects;
using CustomerManagement.Persistence.Contexts;
using CustomerManagement.Persistence.UnitOfWorks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq.Expressions;

namespace CustomerManagement.TDD.Tests.Integration;

public class CustomerIntegrationTests
{
    [Fact]
    public async Task CreateCustomer_Should_Add_Customer_To_Database()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        using (var context = new AppDbContext(options))
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);
            var repository =    unitOfWork.GetWriteRepository<Customer>();
            var mediator = new Mock<IMediator>();
            var createCommand = new CreateCustomerCommandRequest
            {
                FirstName = "ilyas",
                LastName = "Bozdemir",
                DateOfBirth = new DateTime(1996, 12, 04),
                PhoneNumber = "+905554442211",
                Email = "ilyas.b70@domain.com",
                BankAccountNumber = "1234567890123456"
            };
            var handler = new CreateCustomerCommandHandler(unitOfWork, mediator.Object);
            var response = await handler.Handle(createCommand, default);

            Assert.True(response.Success);
            Assert.Equal(200, response.StatusCode);
            Assert.NotNull(response.Data);
        }
    }

    [Fact]
    public async Task CreateCustomer_Should_Return_Error_If_Customer_Already_Exists()
    {
        var unitOfWork = new Mock<IUnitOfWork>();
        var mediator = new Mock<IMediator>();

        var existingCustomer = new Customer
        {
            Id = Guid.NewGuid(),
            FirstName = new Domain.ValueObjects.FirstName("İlyas"),
            LastName = new Domain.ValueObjects.LastName("Bozdemir"),
            Email = new Domain.ValueObjects.Email("ilyas.b70@domain.com"),
            BankAccountNumber = new Domain.ValueObjects.BankAccountNumber("1234567890123456"),
            DateOfBirth = new Domain.ValueObjects.DateOfBirth(new DateTime(2001, 01, 01)),
            PhoneNumber = new Domain.ValueObjects.PhoneNumber("+905554442211")
        };


        unitOfWork.Setup(uow => uow.GetReadRepository<Customer>().GetSingleAsync(It.IsAny<Expression<Func<Customer, bool>>>(), It.IsAny<bool>()))
            .ReturnsAsync(existingCustomer);



        var createCommand = new CreateCustomerCommandRequest
        {
            FirstName = "İlyas",
            LastName = "Bozdemir",
            Email = "ilyas.b70@domain.com",
            BankAccountNumber = "",
            DateOfBirth = new DateTime(2001, 01, 01),
            PhoneNumber = "905554442211"
        };



        var handler = new CreateCustomerCommandHandler(unitOfWork.Object, mediator.Object);

        // Act
        var response = await handler.Handle(createCommand, default);

        // Assert
        Assert.False(response.Success);
    }

    [Fact]
    public async Task CreateCustomer_Should_Validate_PhoneNumber_Email_BankAccountNumber_Uniqueness()//testing
    {

        var options = new DbContextOptionsBuilder<AppDbContext>()
                      .UseInMemoryDatabase(databaseName: "TestDatabase")
                      .Options;
        using (var context = new AppDbContext(options))
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);
            var repository = unitOfWork.GetWriteRepository<Customer>();
            var mediator = new Mock<IMediator>();
            var createCommand = new CreateCustomerCommandRequest
            {
                FirstName = "ilyas",
                LastName = "Bozdemir",
                DateOfBirth = new DateTime(1996, 12, 04),
                PhoneNumber = "05464455",
                Email = "ilyasb70domain.com",
                BankAccountNumber = "1234566"
            };
            var handler = new CreateCustomerCommandHandler(unitOfWork, mediator.Object);
            var response = await handler.Handle(createCommand, default);

            Assert.False(response.Success);
            //Assert.Contains("Invalid phone number.", response.Errors);
            //Assert.Contains("Invalid bank account number.", response.Errors);
            //Assert.Contains("Invalid email.", response.Errors);

        }
    }
}
