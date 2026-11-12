using ProInvoice.Application.Abstraction.Messaging.Commands;
using ProInvoice.Domain.Entities.Invoices.DTOs;

namespace ProInvoice.Application.Features.Invoices.Commands.CreateInvoice;
public record CreateInvoiceCommand(
    CreateInvoiceDto Dto): ICommand<InvoiceResponse>;