using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class TenantJobConfiguration : IEntityTypeConfiguration<TenantJob>
    {
        public void Configure(EntityTypeBuilder<TenantJob> builder)
        {
            builder.HasIndex(j => j.CronId).IsUnique();
        }
    }
}
