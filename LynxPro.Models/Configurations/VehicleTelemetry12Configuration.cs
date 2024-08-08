using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class VehicleTelemetry12Configuration : IEntityTypeConfiguration<VehicleTelemetryPartition12>
    {
        public void Configure(EntityTypeBuilder<VehicleTelemetryPartition12> builder)
        {
            builder.ToTable("VehicleTelemetries12");
            builder.HasKey(c => c.VehicleTelemetryId);
            builder.HasIndex(c => c.TenantId);
            builder.HasIndex(c => c.Timestamp);
            builder.HasIndex(c => c.VehicleId);
            builder.HasIndex(c => new { c.Timestamp, c.VehicleId, c.TenantId });
        }
    }
}
