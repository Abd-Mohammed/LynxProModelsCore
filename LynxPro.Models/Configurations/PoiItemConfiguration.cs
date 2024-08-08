using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class PoiItemConfiguration : IEntityTypeConfiguration<PoiItem>
    {
        public void Configure(EntityTypeBuilder<PoiItem> builder)
        {
            // Composite key
            builder.HasKey(pi => new { pi.PoiGroupId, pi.PoiId });

            // Cascade delete
            builder.HasOne(pi => pi.Poi)
                   .WithMany()
                   .HasForeignKey(pi => pi.PoiId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pi => pi.PoiGroup)
                   .WithMany()
                   .HasForeignKey(pi => pi.PoiGroupId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
