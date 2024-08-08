using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class PudoLocationConfiguration : IEntityTypeConfiguration<PudoLocation>
    {
        public void Configure(EntityTypeBuilder<PudoLocation> builder)
        {
            builder.HasIndex(pl => pl.Name);
        }
    }
}
