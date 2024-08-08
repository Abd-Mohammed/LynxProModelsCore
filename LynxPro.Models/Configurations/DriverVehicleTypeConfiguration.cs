using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class DriverVehicleTypeConfiguration : IEntityTypeConfiguration<DriverVehicleType>
    {
        public void Configure(EntityTypeBuilder<DriverVehicleType> builder)
        {
            // Composite key
            builder.HasKey(dvt => new { dvt.DriverId, dvt.VehicleTypeId });

            builder.HasOne(dvt => dvt.Driver)
                   .WithMany(d => d.DriverVehicleTypes)
                   .HasForeignKey(dvt => dvt.DriverId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(dvt => dvt.VehicleType)
                   .WithMany()
                   .HasForeignKey(dvt => dvt.VehicleTypeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
