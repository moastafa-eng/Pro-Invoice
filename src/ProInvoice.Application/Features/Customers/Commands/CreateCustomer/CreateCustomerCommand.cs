using ProInvoice.Application.Abstraction.Messaging.Commands;
using ProInvoice.Domain.Entities.Customers.DTOs;

namespace ProInvoice.Application.Features.Customers.Commands.CreateCustomer;
public record CreateCustomerCommand(
    CreateCustomerDto Dto) : ICommand<CustomerResponse>;
