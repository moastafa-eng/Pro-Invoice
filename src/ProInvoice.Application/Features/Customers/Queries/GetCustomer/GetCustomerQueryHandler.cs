using AutoMapper;
using ProInvoice.Application.Abstraction.Messaging.Queries;
using ProInvoice.Application.Features.Products.Queries.GetProduct;
using ProInvoice.Domain.Abstraction;
using ProInvoice.Domain.Abstraction.ResultPattern;
using ProInvoice.Domain.Entities.Customers;

namespace ProInvoice.Application.Features.Customers.Queries.GetCustomer;
internal sealed class GetCustomerQueryHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper) : IQueryHandler<GetCustomerQuery, CustomerResponse>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<Result<CustomerResponse>> Handle(
        GetCustomerQuery request,
        CancellationToken cancellationToken)
    {
        var customer = await _unitOfWork.Repository<Customer>()
            .GetByIdAsync(request.CustomerId, cancellationToken);

        if (customer is null)
            return Result<CustomerResponse>
                .Failed(400, "Null.Error", $"The customer with the id: {request.CustomerId} not exist");

        var response = _mapper.Map<CustomerResponse>(customer);

        return Result<CustomerResponse>
            .Success(response, 200);
    }
}
