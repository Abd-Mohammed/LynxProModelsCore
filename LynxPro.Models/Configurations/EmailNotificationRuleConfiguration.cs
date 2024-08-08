using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class EmailNotificationRuleConfiguration : IEntityTypeConfiguration<EmailNotificationRule>
    {
        public void Configure(EntityTypeBuilder<EmailNotificationRule> builder)
        {
            builder.ToTable("EmailNotificationRules");
        }
    }
}
