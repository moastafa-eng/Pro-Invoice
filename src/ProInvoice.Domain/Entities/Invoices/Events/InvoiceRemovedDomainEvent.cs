using ProInvoice.Domain.Abstraction.DomainEvents;
using ProInvoice.Domain.Entities.Shared;

namespace ProInvoice.Domain.Entities.Invoices.Events;

public record InvoiceRemovedDomainEvent(
    Guid CustomerId,
    Money InvoiceValue) : IDomainEvent;