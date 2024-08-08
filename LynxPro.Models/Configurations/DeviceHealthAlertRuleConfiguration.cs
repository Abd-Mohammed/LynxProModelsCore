using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class DeviceHealthAlertRuleConfiguration : IEntityTypeConfiguration<DeviceHealthAlertRule>
    {
        public void Configure(EntityTypeBuilder<DeviceHealthAlertRule> builder)
        {
            // Composite key
            builder.HasKey(dhar => new { dhar.DeviceHealthId, dhar.AlertRuleId });

            builder.HasOne(dh => dh.DeviceHealth)
                   .WithMany(dh => dh.DeviceHealthAlertRules)
                   .HasForeignKey(dhar => dhar.DeviceHealthId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(dh => dh.AlertRule)
                   .WithMany()
                   .HasForeignKey(dhar => dhar.AlertRuleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
