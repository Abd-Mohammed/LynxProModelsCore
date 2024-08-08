using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class RideTypeVehicleTypeConfiguration : IEntityTypeConfiguration<RideTypeVehicleType>
    {
        public void Configure(EntityTypeBuilder<RideTypeVehicleType> builder)
        {
            // Composite key
            builder.HasKey(rtv => new { rtv.RideTypeId, rtv.VehicleTypeId });

            builder.HasOne(rtv => rtv.RideType)
                   .WithMany(r => r.RideTypeVehicleTypes)
                   .HasForeignKey(rtv => rtv.RideTypeId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rtv => rtv.VehicleType)
                   .WithMany()
                   .HasForeignKey(rtv => rtv.VehicleTypeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
