using MediatR;
using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Seedwork;

namespace CustomerManagement.Application.Features.Commands.DeleteCustomer;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommandRequest, DeleteCustomerCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DeleteCustomerCommandResponse> Handle(DeleteCustomerCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var customerReadRepository = _unitOfWork.GetReadRepository<Customer>();
            var existingCustomer = await customerReadRepository.GetByIdAsync(request.CustomerId.ToString());

            if (existingCustomer == null)
                return new DeleteCustomerCommandResponse(false, 404, null, new[] { "Customer not found." });

            var customerWriteRepository = _unitOfWork.GetWriteRepository<Customer>();

            await customerWriteRepository.RemoveAsync(existingCustomer.Id.ToString());


            return new DeleteCustomerCommandResponse(true, 200, existingCustomer); // Müşteri başarıyla silindi
           
        }
        catch (Exception ex)
        {
            return new DeleteCustomerCommandResponse(false, 500, null, new[] { ex.Message });
        }
    }

   
}
