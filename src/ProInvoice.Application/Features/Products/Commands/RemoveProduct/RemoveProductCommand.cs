using ProInvoice.Application.Abstraction.Messaging.Commands;

namespace ProInvoice.Application.Features.Products.Commands.RemoveProduct;
public record RemoveProductCommand(
    Guid ProductId) : ICommand;
