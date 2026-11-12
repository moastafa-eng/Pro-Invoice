using ProInvoice.Application.Abstraction.Messaging.Commands;
using ProInvoice.Domain.Entities.Products.DTOs;

namespace ProInvoice.Application.Features.Products.Commands.CreateProduct;
public record CreateProductCommand(
    CreateProductDto Dto) : ICommand<ProductResponse>;