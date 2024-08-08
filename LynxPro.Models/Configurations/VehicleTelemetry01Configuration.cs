using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class VehicleTelemetry01Configuration : IEntityTypeConfiguration<VehicleTelemetryPartition01>
    {
        public void Configure(EntityTypeBuilder<VehicleTelemetryPartition01> builder)
        {
            builder.ToTable("VehicleTelemetries01");

            builder.HasKey(c => c.VehicleTelemetryId);

            builder.HasIndex(c => c.TenantId);
            builder.HasIndex(c => c.Timestamp);
            builder.HasIndex(c => c.VehicleId);

            builder.HasIndex(c => new { c.Timestamp, c.VehicleId, c.TenantId })
                   .IsClustered(false);
        }
    }
}
