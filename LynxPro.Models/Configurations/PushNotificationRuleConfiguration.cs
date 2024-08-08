using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class PushNotificationRuleConfiguration : IEntityTypeConfiguration<PushNotificationRule>
    {
        public void Configure(EntityTypeBuilder<PushNotificationRule> builder)
        {
            builder.ToTable("PushNotificationRules");
        }
    }
}
