using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasIndex(v => v.Name);
            builder.HasIndex(v => v.PlateNo);

            builder.HasOne(v => v.VehicleType)
                   .WithMany()
                   .HasForeignKey(v => v.VehicleTypeId);

            builder.HasOne(v => v.VehicleCondition)
                   .WithMany()
                   .HasForeignKey(v => v.VehicleConditionId);

            builder.HasOne(v => v.AssignedZone)
                   .WithMany()
                   .HasForeignKey(v => v.AssignedZoneId)
                   .IsRequired(false);

            builder.HasOne(v => v.PrimaryDevice)
                   .WithMany(d => d.PrimaryVehicles)
                   .HasForeignKey(v => v.PrimaryDeviceId)
                   .IsRequired(false);

            builder.HasOne(v => v.SecondaryDevice)
                   .WithMany(d => d.SecondaryVehicles)
                   .HasForeignKey(v => v.SecondaryDeviceId)
                   .IsRequired(false);
        }
    }
}
