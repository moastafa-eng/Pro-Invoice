using ProInvoice.Application.Abstraction.Caching;
using ProInvoice.Application.Abstraction.Messaging.Queries;

namespace ProInvoice.Application.Features.Invoices.Queries.GetInvoice;
public record GetInvoiceQuery(
    Guid InvoiceId) : IQuery<InvoiceResponse>, ICachedQuery
{
    public string CacheKey => $"invoice - {InvoiceId}";

    public TimeSpan? Expiration => null;
}
