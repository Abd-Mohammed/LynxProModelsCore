using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class ProductInventoryConfiguration : IEntityTypeConfiguration<ProductInventory>
    {
        public void Configure(EntityTypeBuilder<ProductInventory> builder)
        {
            // Composite key
            builder.HasKey(pi => new { pi.WarehouseId, pi.ProductId });

            // Cascade delete
            builder.HasOne(pi => pi.Warehouse)
                   .WithMany()
                   .HasForeignKey(pi => pi.WarehouseId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pi => pi.Product)
                   .WithMany()
                   .HasForeignKey(pi => pi.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
