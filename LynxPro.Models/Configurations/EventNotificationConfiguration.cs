using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class EventNotificationConfiguration : IEntityTypeConfiguration<EventNotification>
    {
        public void Configure(EntityTypeBuilder<EventNotification> builder)
        {
            builder.HasIndex(en => en.CreatedDate);
            builder.HasIndex(en => en.UserId);
            builder.HasIndex(en => en.TenantId);
            builder.HasIndex(en => new { en.UserId, en.TenantId }).IsUnique(false);
        }
    }
}
