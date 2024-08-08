using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class PoiConfiguration : IEntityTypeConfiguration<Poi>
    {
        public void Configure(EntityTypeBuilder<Poi> builder)
        {
            builder.HasIndex(p => p.Name);
        }
    }
}
