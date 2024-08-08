using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class EscalationRuleNotifRuleConfiguration : IEntityTypeConfiguration<EscalationRuleNotificationRule>
    {
        public void Configure(EntityTypeBuilder<EscalationRuleNotificationRule> builder)
        {
            // Composite key
            builder.HasKey(ernr => new { ernr.EscalationRuleId, ernr.NotificationRuleId });

            builder.HasOne(ernr => ernr.EscalationRule)
                   .WithMany(ar => ar.EscalationRuleNotificationRules)
                   .HasForeignKey(ernr => ernr.EscalationRuleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ernr => ernr.NotificationRule)
                   .WithMany()
                   .HasForeignKey(ernr => ernr.NotificationRuleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
