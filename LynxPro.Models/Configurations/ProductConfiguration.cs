using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasIndex(p => p.Number);
            builder.HasIndex(p => p.Name);

            builder.Property(p => p.PriceAmount)
                   .HasColumnType("decimal(19, 4)");
        }
    }
}
