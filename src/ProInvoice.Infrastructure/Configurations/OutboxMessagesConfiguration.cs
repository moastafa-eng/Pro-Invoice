using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProInvoice.Infrastructure.Outbox;

namespace ProInvoice.Infrastructure.Configurations;
internal sealed class OutboxMessagesConfiguration : IEntityTypeConfiguration<OutboxMessage>
{
    public void Configure(EntityTypeBuilder<OutboxMessage> builder)
    {  
        builder.Property(outboxMessages => outboxMessages.Content)
            .HasColumnType("nvarchar(max)")
            .IsRequired();
    }
}