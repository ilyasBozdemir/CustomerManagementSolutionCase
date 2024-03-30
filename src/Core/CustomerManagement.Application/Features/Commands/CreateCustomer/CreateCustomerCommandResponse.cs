using CustomerManagement.Domain.Results;

namespace CustomerManagement.Application.Features.Commands.CreateCustomer;

public class CreateCustomerCommandResponse : CommandResult
{
    public CreateCustomerCommandResponse(bool success, int statusCode, string[] errors = null)
    : base(success, statusCode, errors) { }

    public CreateCustomerCommandResponse(bool success, int statusCode = 200)
        : base(success, statusCode) { }
    public CreateCustomerCommandResponse() { }

}