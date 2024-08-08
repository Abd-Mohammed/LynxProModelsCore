using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class VehicleQuarantineLogConfiguration : IEntityTypeConfiguration<VehicleQuarantineLog>
    {
        public void Configure(EntityTypeBuilder<VehicleQuarantineLog> builder)
        {
            builder.HasIndex(vql => vql.Name);
            builder.HasIndex(vql => vql.PlateNo);
            builder.HasIndex(vql => vql.Time);
            builder.HasIndex(vql => vql.StartTime);
            builder.HasIndex(vql => vql.EndTime);
            builder.HasIndex(vql => vql.WasActivated);
            builder.HasIndex(vql => vql.WasBreached);
        }
    }
}
