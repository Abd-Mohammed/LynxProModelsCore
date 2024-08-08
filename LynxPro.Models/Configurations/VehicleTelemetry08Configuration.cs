using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class VehicleTelemetry08Configuration : IEntityTypeConfiguration<VehicleTelemetryPartition08>
    {
        public void Configure(EntityTypeBuilder<VehicleTelemetryPartition08> builder)
        {
            builder.ToTable("VehicleTelemetries08");
            builder.HasKey(c => c.VehicleTelemetryId);
            builder.HasIndex(c => c.TenantId);
            builder.HasIndex(c => c.Timestamp);
            builder.HasIndex(c => c.VehicleId);
            builder.HasIndex(c => new { c.Timestamp, c.VehicleId, c.TenantId });
        }
    }
}
