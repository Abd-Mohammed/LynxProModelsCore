using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class ActivityLogConfiguration : IEntityTypeConfiguration<ActivityLog>
    {
        public void Configure(EntityTypeBuilder<ActivityLog> builder)
        {
            builder.HasIndex(al => al.EntityKey);
            builder.HasIndex(al => al.EntityName);
            builder.HasIndex(al => al.TenantId);
        }
    }
}
