using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class VehicleRideStateConfiguration : IEntityTypeConfiguration<VehicleRideState>
    {
        public void Configure(EntityTypeBuilder<VehicleRideState> builder)
        {
            // Primary key
            builder.HasKey(vrs => vrs.VehicleId);

            builder.HasIndex(vrs => vrs.LastEventTime);
            builder.HasIndex(vrs => vrs.MeterStatus);
            builder.HasIndex(vrs => vrs.MeterLastContactTime);

            builder.HasOne(vrs => vrs.Vehicle)
                   .WithOne(v => v.VehicleRideState)
                   .HasForeignKey<VehicleRideState>(vrs => vrs.VehicleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(vrs => vrs.RideRequest)
                   .WithMany()
                   .HasForeignKey(vrs => vrs.RideRequestId)
                   .IsRequired(false);

            builder.HasOne(vrs => vrs.LastRideRequest)
                   .WithMany()
                   .HasForeignKey(vrs => vrs.LastRideRequestId)
                   .IsRequired(false);

            builder.HasOne(vrs => vrs.Ride)
                   .WithMany()
                   .HasForeignKey(vrs => vrs.RideId)
                   .IsRequired(false);

            builder.HasOne(vrs => vrs.LastFailedRide)
                   .WithMany()
                   .HasForeignKey(vrs => vrs.LastFailedRideId)
                   .IsRequired(false);

            builder.HasOne(vrs => vrs.LastSucceededRide)
                   .WithMany()
                   .HasForeignKey(vrs => vrs.LastSucceededRideId)
                   .IsRequired(false);

            builder.Property(r => r.TotalIncome).HasColumnType("decimal(19, 4)");
        }
    }
}
