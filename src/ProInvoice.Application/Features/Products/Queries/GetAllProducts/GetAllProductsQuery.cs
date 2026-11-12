using ProInvoice.Application.Abstraction.Messaging.Queries;

namespace ProInvoice.Application.Features.Products.Queries.GetAllProducts;
public record GetAllProductsQuery : IQuery<ProductResponseCollection>;
