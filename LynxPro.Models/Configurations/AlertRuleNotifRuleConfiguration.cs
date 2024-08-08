using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class AlertRuleNotifRuleConfiguration : IEntityTypeConfiguration<AlertRuleNotificationRule>
    {
        public void Configure(EntityTypeBuilder<AlertRuleNotificationRule> builder)
        {
            // Composite key
            builder.HasKey(an => new { an.AlertRuleId, an.NotificationRuleId });

            // Cascade delete
            builder.HasOne(an => an.AlertRule)
                   .WithMany(ar => ar.AlertRuleNotificationRules)
                   .HasForeignKey(an => an.AlertRuleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(an => an.NotificationRule)
                   .WithMany()
                   .HasForeignKey(an => an.NotificationRuleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
