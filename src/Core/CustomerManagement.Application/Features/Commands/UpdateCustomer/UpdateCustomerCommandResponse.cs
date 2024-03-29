using CustomerManagement.Application.Features.Results;
using CustomerManagement.Domain.Entities;

namespace CustomerManagement.Application.Features.Commands.UpdateCustomer;

public class UpdateCustomerCommandResponse : CommandResult<Customer>
{
    public UpdateCustomerCommandResponse(bool success, int statusCode, Customer data, string[] errors = null)
        : base(success, statusCode, data, errors) { }

    public UpdateCustomerCommandResponse(bool success, int statusCode, string[] errors = null)
        : base(success, statusCode, null, errors) { }
}
