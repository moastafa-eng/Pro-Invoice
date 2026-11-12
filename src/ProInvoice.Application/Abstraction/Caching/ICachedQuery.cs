namespace ProInvoice.Application.Abstraction.Caching;
public interface ICachedQuery
{
    string CacheKey { get; }
    TimeSpan? Expiration { get; }
}
