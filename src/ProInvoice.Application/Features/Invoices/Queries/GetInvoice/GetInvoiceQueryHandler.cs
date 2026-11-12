using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProInvoice.Application.Abstraction.Messaging.Queries;
using ProInvoice.Domain.Abstraction;
using ProInvoice.Domain.Abstraction.ResultPattern;
using ProInvoice.Domain.Entities.Invoices;

namespace ProInvoice.Application.Features.Invoices.Queries.GetInvoice;
internal sealed class GetInvoiceQueryHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper) : IQueryHandler<GetInvoiceQuery, InvoiceResponse>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<Result<InvoiceResponse>> Handle(
        GetInvoiceQuery request,
        CancellationToken cancellationToken)
    {
        var response = await _unitOfWork.Repository<Invoice>()
            .GetAll()
            .Include(x => x.PurchasedProducts)
            .ProjectTo<InvoiceResponse>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == request.InvoiceId, cancellationToken);

        if (response == null)
            return Result<InvoiceResponse>
                .Failed(400, "Null.Error", $"The invoice with the id: {request.InvoiceId} not exist");

        return Result<InvoiceResponse>
            .Success(response, 200);
    }
}
