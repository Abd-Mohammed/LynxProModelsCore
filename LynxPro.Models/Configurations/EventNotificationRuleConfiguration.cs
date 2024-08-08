using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class EventNotificationRuleConfiguration : IEntityTypeConfiguration<EventNotificationRule>
    {
        public void Configure(EntityTypeBuilder<EventNotificationRule> builder)
        {
            builder.ToTable("EventNotificationRules");
        }
    }
}
