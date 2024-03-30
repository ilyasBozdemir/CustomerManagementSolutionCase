using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Results;

namespace CustomerManagement.Application.Features.Commands.DeleteCustomer;
public class DeleteCustomerCommandResponse : CommandResult<Customer>
{
    public DeleteCustomerCommandResponse(bool success, int statusCode, Customer data, string[] errors = null)
        : base(success, statusCode, data, errors) { }

    public DeleteCustomerCommandResponse(bool success, int statusCode, string[] errors = null)
        : base(success, statusCode, null, errors) { }
}