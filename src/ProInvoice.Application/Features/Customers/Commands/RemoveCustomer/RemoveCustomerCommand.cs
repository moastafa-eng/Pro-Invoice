
using ProInvoice.Application.Abstraction.Messaging.Commands;

namespace ProInvoice.Application.Features.Customers.Commands.RemoveCustomer;
public record RemoveCustomerCommand(
    Guid CustomerId) : ICommand;
