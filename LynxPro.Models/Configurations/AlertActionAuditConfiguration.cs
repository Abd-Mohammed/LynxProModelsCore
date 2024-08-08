using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class AlertActionAuditConfiguration : IEntityTypeConfiguration<AlertActionAudit>
    {
        public void Configure(EntityTypeBuilder<AlertActionAudit> builder)
        {
            builder.Property(p => p.TriggeredDate).HasColumnType("datetime");
        }
    }
}
