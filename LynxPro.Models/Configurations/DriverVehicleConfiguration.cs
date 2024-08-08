using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class DriverVehicleConfiguration : IEntityTypeConfiguration<DriverVehicle>
    {
        public void Configure(EntityTypeBuilder<DriverVehicle> builder)
        {
            // Composite key
            builder.HasKey(dv => new { dv.DriverId, dv.VehicleId });

            builder.HasOne(dv => dv.Driver)
                   .WithMany(d => d.DriverVehicles)
                   .HasForeignKey(dv => dv.DriverId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(dv => dv.Vehicle)
                   .WithMany(v => v.DriverVehicles)
                   .HasForeignKey(dv => dv.VehicleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
