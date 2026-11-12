using ProInvoice.Application.Abstraction.Caching;
using ProInvoice.Application.Abstraction.Messaging.Queries;

namespace ProInvoice.Application.Features.Customers.Queries.GetCustomer;
public record GetCustomerQuery(
    Guid CustomerId) : IQuery<CustomerResponse>, ICachedQuery
{
    public string CacheKey => $"customer-{CustomerId}";

    public TimeSpan? Expiration => null;
}
