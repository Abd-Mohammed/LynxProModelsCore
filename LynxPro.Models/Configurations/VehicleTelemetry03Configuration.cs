using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class VehicleTelemetry03Configuration : IEntityTypeConfiguration<VehicleTelemetryPartition03>
    {
        public void Configure(EntityTypeBuilder<VehicleTelemetryPartition03> builder)
        {
            builder.ToTable("VehicleTelemetries03");
            builder.HasKey(c => c.VehicleTelemetryId);
            builder.HasIndex(c => c.TenantId);
            builder.HasIndex(c => c.Timestamp);
            builder.HasIndex(c => c.VehicleId);
            builder.HasIndex(c => new { c.Timestamp, c.VehicleId, c.TenantId });
        }
    }
}
