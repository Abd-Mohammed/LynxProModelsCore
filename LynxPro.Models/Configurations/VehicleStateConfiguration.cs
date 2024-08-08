using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class VehicleStateConfiguration : IEntityTypeConfiguration<VehicleState>
    {
        public void Configure(EntityTypeBuilder<VehicleState> builder)
        {
            // Primary key
            builder.HasKey(vs => vs.VehicleId);

            builder.HasOne(vs => vs.Vehicle)
                   .WithOne(b => b.VehicleState)
                   .HasForeignKey<VehicleState>(vs => vs.VehicleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(vs => vs.DirectionsRoute)
                   .WithMany()
                   .HasForeignKey(vs => vs.DirectionsRouteId)
                   .IsRequired(false);

            builder.HasOne(vs => vs.ActRoute)
                   .WithMany()
                   .HasForeignKey(vs => vs.ActRouteId)
                   .IsRequired(false);

            builder.HasOne(vs => vs.ActShift)
                   .WithMany()
                   .HasForeignKey(vs => vs.ActShiftId)
                   .IsRequired(false);

            builder.HasOne(vs => vs.Driver)
                   .WithMany()
                   .HasForeignKey(vs => vs.DriverId)
                   .IsRequired(false);
        }
    }
}
