using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class EscalationRuleActionConfiguration : IEntityTypeConfiguration<EscalationRuleAction>
    {
        public void Configure(EntityTypeBuilder<EscalationRuleAction> builder)
        {
            // Composite key
            builder.HasKey(era => new { era.EscalationRuleId, era.ActionId });

            // Cascade delete
            builder.HasOne(era => era.EscalationRule)
                   .WithMany(ae => ae.EscalationRuleActions)
                   .HasForeignKey(era => era.EscalationRuleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(era => era.Action)
                   .WithMany()
                   .HasForeignKey(era => era.ActionId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
