using ProInvoice.Application.Abstraction.Messaging.Commands;

namespace ProInvoice.Application.Features.Invoices.Commands.RemoveInvoice;
public record RemoveInvoiceCommand(
    Guid InvoiceId) : ICommand;