using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class AlertRuleTagConfiguration : IEntityTypeConfiguration<AlertRuleTag>
    {
        public void Configure(EntityTypeBuilder<AlertRuleTag> builder)
        {
            // Composite key
            builder.HasKey(ara => new { ara.AlertRuleId, ara.TagId });

            // Cascade delete
            builder.HasOne(ara => ara.AlertRule)
                   .WithMany(ar => ar.AlertRuleTags)
                   .HasForeignKey(ara => ara.AlertRuleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ara => ara.Tag)
                   .WithMany()
                   .HasForeignKey(ara => ara.TagId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
