using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class VehicleTelemetry10Configuration : IEntityTypeConfiguration<VehicleTelemetryPartition10>
    {
        public void Configure(EntityTypeBuilder<VehicleTelemetryPartition10> builder)
        {
            builder.ToTable("VehicleTelemetries10");
            builder.HasKey(c => c.VehicleTelemetryId);
            builder.HasIndex(c => c.TenantId);
            builder.HasIndex(c => c.Timestamp);
            builder.HasIndex(c => c.VehicleId);
            builder.HasIndex(c => new { c.Timestamp, c.VehicleId, c.TenantId });
        }
    }
}
