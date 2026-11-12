using ProInvoice.Domain.Abstraction.DomainEvents;

namespace ProInvoice.Domain.Entities.Invoices.Events;
public record InvoiceCreatedDomainEvent(
    Guid InvoiceId) : IDomainEvent;