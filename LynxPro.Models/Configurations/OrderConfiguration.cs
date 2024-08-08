using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasIndex(o => o.Number);
            builder.HasIndex(o => o.Date);
            builder.HasIndex(o => o.Status);
            builder.HasIndex(o => o.LastStatusUpdatedDate);

            builder.Property(p => p.Subtotal)
                   .HasColumnType("decimal(19, 4)");

            builder.Property(p => p.PriceAmount)
                   .HasColumnType("decimal(19, 4)");
        }
    }
}
