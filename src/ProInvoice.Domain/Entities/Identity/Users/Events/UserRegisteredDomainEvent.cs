using ProInvoice.Domain.Abstraction.DomainEvents;

namespace ProInvoice.Domain.Entities.Identity.Users.Events;
public record UserRegisteredDomainEvent(
    Guid UserId,
    string? AdminKey) : IDomainEvent;
