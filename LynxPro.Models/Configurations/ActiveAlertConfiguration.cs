using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class ActiveAlertConfiguration : IEntityTypeConfiguration<ActiveAlert>
    {
        public void Configure(EntityTypeBuilder<ActiveAlert> builder)
        {
            builder.HasIndex(aa => aa.RefId);
            builder.HasIndex(aa => aa.OpenDate);
            builder.HasIndex(aa => aa.LastDate);
            builder.HasIndex(aa => aa.ResolvedDate);
            builder.HasIndex(aa => aa.ServerTimestamp);
            builder.HasIndex(aa => aa.IsFalse);
            builder.HasIndex(aa => aa.IsSlaBreached);
            builder.HasIndex(aa => aa.IsViolation);
            builder.HasIndex(aa => aa.HasBlobs);
        }
    }
}
