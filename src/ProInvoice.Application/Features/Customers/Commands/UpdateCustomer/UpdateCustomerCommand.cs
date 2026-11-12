using ProInvoice.Application.Abstraction.Messaging.Commands;
using ProInvoice.Domain.Entities.Customers.DTOs;

namespace ProInvoice.Application.Features.Customers.Commands.UpdateCustomer;
public record UpdateCustomerCommand(
    Guid CustomerId,
    UpdateCustomerDto Dto) : ICommand;