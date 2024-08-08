using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class AlertConfiguration : IEntityTypeConfiguration<Alert>
    {
        public void Configure(EntityTypeBuilder<Alert> builder)
        {
            builder.HasIndex(a => a.RefId);
            builder.HasIndex(a => a.OpenDateTime);
            builder.HasIndex(a => a.LastDateTime);

            builder.Property(a => a.ResolvedDate).HasColumnType("datetime");
            builder.Property(a => a.ServerTimestamp).HasColumnType("datetime");
        }
    }
}
