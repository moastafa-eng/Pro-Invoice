using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProInvoice.Application.Abstraction.Messaging.Queries;
using ProInvoice.Domain.Abstraction;
using ProInvoice.Domain.Abstraction.ResultPattern;
using ProInvoice.Domain.Entities.Products;

namespace ProInvoice.Application.Features.Products.Queries.GetAllProducts;
internal sealed class GetAllProductsQueryHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper) : IQueryHandler<GetAllProductsQuery, ProductResponseCollection>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<Result<ProductResponseCollection>> Handle(
        GetAllProductsQuery request,
        CancellationToken cancellationToken)
    {
        var products = await _unitOfWork
            .Repository<Product>()
            .GetAll()
            .ProjectTo<ProductResponse>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        var response = new ProductResponseCollection
        {
            Products = products.AsReadOnly()
        };

        return Result<ProductResponseCollection>
            .Success(response, 200);
    }
}
