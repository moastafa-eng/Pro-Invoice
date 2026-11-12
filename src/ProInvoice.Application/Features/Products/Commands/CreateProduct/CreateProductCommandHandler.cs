using AutoMapper;
using ProInvoice.Application.Abstraction.Messaging.Commands;
using ProInvoice.Domain.Abstraction;
using ProInvoice.Domain.Abstraction.ResultPattern;
using ProInvoice.Domain.Entities.Products;

namespace ProInvoice.Application.Features.Products.Commands.CreateProduct;

internal sealed class CreateProductCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper) : ICommandHandler<CreateProductCommand, ProductResponse>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<Result<ProductResponse>> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = Product.Create(request.Dto);

        await _unitOfWork.Repository<Product>()
            .CreateAsync(product, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);

        var response = _mapper.Map<ProductResponse>(product);

        return Result<ProductResponse>
            .Success(response, 201);
    }
}
