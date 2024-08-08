using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class AlertRuleActionConfiguration : IEntityTypeConfiguration<AlertRuleAction>
    {
        public void Configure(EntityTypeBuilder<AlertRuleAction> builder)
        {
            // Composite key
            builder.HasKey(ara => new { ara.AlertRuleId, ara.ActionId });

            // Cascade delete
            builder.HasOne(ara => ara.AlertRule)
                   .WithMany(ar => ar.AlertRuleActions)
                   .HasForeignKey(ara => ara.AlertRuleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ara => ara.Action)
                   .WithMany()
                   .HasForeignKey(ara => ara.ActionId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
