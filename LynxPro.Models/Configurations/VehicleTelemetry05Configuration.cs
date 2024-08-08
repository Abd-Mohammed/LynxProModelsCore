using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class VehicleTelemetry05Configuration : IEntityTypeConfiguration<VehicleTelemetryPartition05>
    {
        public void Configure(EntityTypeBuilder<VehicleTelemetryPartition05> builder)
        {
            builder.ToTable("VehicleTelemetries05");
            builder.HasKey(c => c.VehicleTelemetryId);
            builder.HasIndex(c => c.TenantId);
            builder.HasIndex(c => c.Timestamp);
            builder.HasIndex(c => c.VehicleId);
            builder.HasIndex(c => new { c.Timestamp, c.VehicleId, c.TenantId });
        }
    }
}
