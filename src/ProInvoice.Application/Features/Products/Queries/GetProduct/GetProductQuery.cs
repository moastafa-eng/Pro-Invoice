using ProInvoice.Application.Abstraction.Caching;
using ProInvoice.Application.Abstraction.Messaging.Queries;

namespace ProInvoice.Application.Features.Products.Queries.GetProduct;
public record GetProductQuery(
    Guid ProductId) : IQuery<ProductResponse>, ICachedQuery
{
    public string CacheKey => $"product - {ProductId}";

    public TimeSpan? Expiration => null;
}
