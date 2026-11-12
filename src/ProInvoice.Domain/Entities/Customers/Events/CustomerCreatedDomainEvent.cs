using ProInvoice.Domain.Abstraction.DomainEvents;

namespace ProInvoice.Domain.Entities.Customers.Events;
public record CustomerCreatedDomainEvent(Guid CustomerId) : IDomainEvent;
