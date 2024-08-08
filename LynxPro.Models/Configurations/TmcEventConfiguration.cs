using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class TmcEventConfiguration : IEntityTypeConfiguration<TmcEvent>
    {
        public void Configure(EntityTypeBuilder<TmcEvent> builder)
        {
            builder.HasIndex(te => new { te.Name, te.TenantId }).IsUnique();
        }
    }
}
