using ProInvoice.Application.Abstraction.Messaging.Commands;
using ProInvoice.Domain.Entities.Invoices.DTOs;

namespace ProInvoice.Application.Features.Invoices.Commands.UpdateInvoice;
public record UpdateInvoiceCommand(
    Guid InvoiceId,
    UpdateInvoiceDto Dto) : ICommand;
