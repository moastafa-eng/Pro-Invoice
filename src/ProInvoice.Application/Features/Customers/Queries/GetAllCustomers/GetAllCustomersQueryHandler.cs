using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProInvoice.Application.Abstraction.Messaging.Queries;
using ProInvoice.Domain.Abstraction;
using ProInvoice.Domain.Abstraction.ResultPattern;
using ProInvoice.Domain.Entities.Customers;

namespace ProInvoice.Application.Features.Customers.Queries.GetAllCustomers;
internal sealed class GetAllCustomersQueryHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper) : IQueryHandler<GetAllCustomersQuery, CustomerResponseCollection>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<Result<CustomerResponseCollection>> Handle(
        GetAllCustomersQuery request,
        CancellationToken cancellationToken)
    {
        var customers = await _unitOfWork.Repository<Customer>()
            .GetAll()
            .ProjectTo<CustomerResponse>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        var response = new CustomerResponseCollection
        {
            Customers = customers.AsReadOnly()
        };

        return Result<CustomerResponseCollection>
            .Success(response,200);
    }
}
