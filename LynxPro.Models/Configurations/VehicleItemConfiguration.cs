using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class VehicleItemConfiguration : IEntityTypeConfiguration<VehicleItem>
    {
        public void Configure(EntityTypeBuilder<VehicleItem> builder)
        {
            // Composite key
            builder.HasKey(vi => new { vi.VehicleGroupId, vi.VehicleId });

            builder.HasOne(vi => vi.Vehicle)
                   .WithMany()
                   .HasForeignKey(vi => vi.VehicleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(vi => vi.VehicleGroup)
                   .WithMany()
                   .HasForeignKey(vi => vi.VehicleGroupId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
