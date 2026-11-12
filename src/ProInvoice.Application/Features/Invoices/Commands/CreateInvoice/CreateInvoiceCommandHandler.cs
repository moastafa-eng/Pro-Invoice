using AutoMapper;
using ProInvoice.Application.Abstraction.Messaging.Commands;
using ProInvoice.Domain.Abstraction;
using ProInvoice.Domain.Abstraction.ResultPattern;
using ProInvoice.Domain.Entities.Invoices;

namespace ProInvoice.Application.Features.Invoices.Commands.CreateInvoice;
internal sealed class CreateInvoiceCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper) : ICommandHandler<CreateInvoiceCommand, InvoiceResponse>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<Result<InvoiceResponse>> Handle(
        CreateInvoiceCommand request,
        CancellationToken cancellationToken)
    {
        var invoice = await Invoice.Create(request.Dto, _unitOfWork);

        await _unitOfWork.Repository<Invoice>()
            .CreateAsync(invoice, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);

        var respose = _mapper.Map<InvoiceResponse>(invoice);

        return Result<InvoiceResponse>
            .Success(respose, 201);
    }
}
