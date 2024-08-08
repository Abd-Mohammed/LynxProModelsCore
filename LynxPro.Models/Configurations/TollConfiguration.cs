using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class TollConfiguration : IEntityTypeConfiguration<Toll>
    {
        public void Configure(EntityTypeBuilder<Toll> builder)
        {
            builder.HasIndex(t => t.CurrencyCode);

            builder.Property(t => t.Fee).HasColumnType("decimal(19, 4)");
        }
    }
}
