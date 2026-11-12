using ProInvoice.Application.Abstraction.Messaging.Commands;
using ProInvoice.Domain.Abstraction;
using ProInvoice.Domain.Abstraction.ResultPattern;
using ProInvoice.Domain.Entities.Products;

namespace ProInvoice.Application.Features.Products.Commands.UpdateProduct;
internal sealed class UpdateProductCommandHandler(
    IUnitOfWork unitOfWork) : ICommandHandler<UpdateProductCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<NoContentDto>> Handle(
        UpdateProductCommand request, 
        CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Repository<Product>()
            .GetByIdAsync(request.ProductId, cancellationToken);

        if (product is null)
            return Result<NoContentDto>
                .Failed(400, "Null.Error", $"The product with the id: {request.ProductId} not exist");

        product.Update(request.Dto);

        _unitOfWork.Repository<Product>()
            .Update(product);

        await _unitOfWork.CommitAsync(
            cancellationToken,
            checkForConcurrency: true);

        return Result<NoContentDto>
            .Success(204);
    }
}
