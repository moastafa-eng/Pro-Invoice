using ProInvoice.Application.Abstraction.Messaging.Commands;
using ProInvoice.Domain.Entities.Products.DTOs;

namespace ProInvoice.Application.Features.Products.Commands.UpdateProduct;
public record UpdateProductCommand(
    Guid ProductId,
    UpdateProductDto Dto) : ICommand;
