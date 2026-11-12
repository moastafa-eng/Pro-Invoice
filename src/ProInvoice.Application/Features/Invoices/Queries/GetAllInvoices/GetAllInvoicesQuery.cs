using ProInvoice.Application.Abstraction.Messaging.Queries;

namespace ProInvoice.Application.Features.Invoices.Queries.GetAllInvoices;
public record GetAllInvoicesQuery : IQuery<InvoiceResponseCollection>;