using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class OrderLineConfiguration : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.Property(ol => ol.PriceAmount)
                   .HasColumnType("decimal(19, 4)");

            builder.Property(ol => ol.TaxAmount)
                   .HasColumnType("decimal(19, 4)");

            builder.Property(ol => ol.TotalAmount)
                   .HasColumnType("decimal(19, 4)");

            builder.HasOne(ol => ol.Order)
                   .WithMany(o => o.OrderLines)
                   .HasForeignKey(ol => ol.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
