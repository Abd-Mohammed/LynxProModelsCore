using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class AreaItemConfiguration : IEntityTypeConfiguration<AreaItem>
    {
        public void Configure(EntityTypeBuilder<AreaItem> builder)
        {
            // Composite key
            builder.HasKey(ai => new { ai.AreaGroupId, ai.AreaId });

            // Cascade delete
            builder.HasOne(ai => ai.Area)
                   .WithMany()
                   .HasForeignKey(ai => ai.AreaId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ai => ai.AreaGroup)
                   .WithMany()
                   .HasForeignKey(ai => ai.AreaGroupId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
