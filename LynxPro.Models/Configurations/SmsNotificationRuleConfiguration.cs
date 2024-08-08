using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class SmsNotificationRuleConfiguration : IEntityTypeConfiguration<SmsNotificationRule>
    {
        public void Configure(EntityTypeBuilder<SmsNotificationRule> builder)
        {
            builder.ToTable("SmsNotificationRules");
        }
    }
}
