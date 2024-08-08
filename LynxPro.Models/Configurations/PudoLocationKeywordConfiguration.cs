using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class PudoLocationKeywordConfiguration : IEntityTypeConfiguration<PudoLocationKeyword>
    {
        public void Configure(EntityTypeBuilder<PudoLocationKeyword> builder)
        {
            builder.HasIndex(plk => plk.Name);

            builder.HasOne(plk => plk.PudoLocation)
                   .WithMany(pl => pl.PudoLocationKeywords)
                   .HasForeignKey(plk => plk.PudoLocationId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
