using AutoMapper;
using ProInvoice.Application.Abstraction.Messaging.Commands;
using ProInvoice.Domain.Abstraction;
using ProInvoice.Domain.Abstraction.ResultPattern;
using ProInvoice.Domain.Entities.Customers;

namespace ProInvoice.Application.Features.Customers.Commands.CreateCustomer;
internal sealed class CreateCustomerCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper) : ICommandHandler<CreateCustomerCommand, CustomerResponse>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<Result<CustomerResponse>> Handle(
        CreateCustomerCommand request, 
        CancellationToken cancellationToken)
    {
        var customer = Customer.Create(request.Dto);

        await _unitOfWork.Repository<Customer>()
            .CreateAsync(customer);

        await _unitOfWork.CommitAsync(cancellationToken);

        var response = _mapper.Map<CustomerResponse>(customer);

        return Result<CustomerResponse>
            .Success(response, 201);
    }
}
