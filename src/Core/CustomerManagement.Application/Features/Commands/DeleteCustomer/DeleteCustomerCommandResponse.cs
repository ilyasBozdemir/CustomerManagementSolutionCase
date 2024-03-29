using CustomerManagement.Application.Features.Results;
using CustomerManagement.Domain.Entities;

namespace CustomerManagement.Application.Features.Commands.DeleteCustomer;
public class DeleteCustomerCommandResponse : CommandResult<Customer>
{
    public DeleteCustomerCommandResponse(bool success, int statusCode, Customer data, string[] errors = null)
        : base(success, statusCode, data, errors) { }

    public DeleteCustomerCommandResponse(bool success, int statusCode, string[] errors = null)
        : base(success, statusCode, null, errors) { }
}