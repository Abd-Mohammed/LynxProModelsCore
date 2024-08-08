using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class DriverRideStatisticsConfiguration : IEntityTypeConfiguration<DriverRideStatistics>
    {
        public void Configure(EntityTypeBuilder<DriverRideStatistics> builder)
        {
            // Primary key
            builder.HasKey(drs => drs.DriverId);

            builder.HasOne(drs => drs.Driver)
                   .WithOne(d => d.RideStatistics)
                   .HasForeignKey<DriverRideStatistics>(drs => drs.DriverId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
