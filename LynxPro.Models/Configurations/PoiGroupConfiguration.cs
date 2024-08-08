using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class PoiGroupConfiguration : IEntityTypeConfiguration<PoiGroup>
    {
        public void Configure(EntityTypeBuilder<PoiGroup> builder)
        {
            builder.HasIndex(pg => pg.Name);
        }
    }
}
