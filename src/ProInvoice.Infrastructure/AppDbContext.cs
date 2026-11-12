using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection;
using ProInvoice.Domain.Abstraction.DomainEvents;
using ProInvoice.Domain.Abstraction.Entity;
using ProInvoice.Domain.Attributes;
using ProInvoice.Domain.Entities.Customers;
using ProInvoice.Domain.Entities.Identity.Roles;
using ProInvoice.Domain.Entities.Identity.Users;
using ProInvoice.Domain.Entities.InvoiceItems;
using ProInvoice.Domain.Entities.Invoices;
using ProInvoice.Domain.Entities.Products;
using ProInvoice.Domain.Exceptions;
using ProInvoice.Infrastructure.Outbox;

namespace ProInvoice.Infrastructure;
public class AppDbContext : IdentityDbContext<AppUser,AppRole,Guid>
{
    private static readonly JsonSerializerSettings JsonSerializerSettings = new()
    {
        TypeNameHandling = TypeNameHandling.All,
    };

    public AppDbContext(
        DbContextOptions options) : base(options) { }

    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Invoice> Invoices { get; set; } = null!;
    public DbSet<InvoiceItem> InvoiceItems { get; set; } = null!;
    public DbSet<OutboxMessage> OutboxMessages { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        ProcessAutoseedData(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AddDomainEventsAsOutboxMessages();

        var result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }

    private void AddDomainEventsAsOutboxMessages()
    {
        var outboxMessages = ChangeTracker
            .Entries<IDomainEventRaiser>()
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                var domainEvents = entity.GetDomainEvents();

                entity.ClearDomainEvents();

                return domainEvents;
            })
            .Select(domainEvent => new OutboxMessage(
                Guid.NewGuid(),
                DateTime.UtcNow,
                domainEvent.GetType().Name,
                JsonConvert.SerializeObject(domainEvent, JsonSerializerSettings)))
            .ToList();

        AddRange(outboxMessages);
    }

    private void ProcessAutoseedData(ModelBuilder modelBuilder)
    {
        var entityTypes = modelBuilder.Model.GetEntityTypes()
            .Select(x => x.ClrType)
            .Where(x => x.GetInterface(nameof(IHaveAutoseedData)) != null)
            .SelectMany(e => e.GetProperties())
            .Where(e => e.GetCustomAttribute<AutoSeedDataAttribute>() != null)
            .GroupBy(e => e.DeclaringType)
            .ToList();

        foreach (var group in entityTypes)
        {
            var entityType = modelBuilder.Entity(group.Key!);

            foreach (var property in group)
            {
                var value = property.GetValue(Activator.CreateInstance(property.DeclaringType!));

                entityType.HasData(value ?? throw new InternalServerException(
                    "AutoseedFailure.Error",
                    ["PropertyInfo value null error"]));
            }
        }
    }
}
