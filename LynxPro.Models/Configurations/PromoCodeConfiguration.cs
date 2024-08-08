using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class PromoCodeConfiguration : IEntityTypeConfiguration<PromoCode>
    {
        public void Configure(EntityTypeBuilder<PromoCode> builder)
        {
            builder.HasIndex(pc => pc.Name);
            builder.HasIndex(pc => pc.Type);
            builder.HasIndex(pc => pc.DiscountType);
            builder.HasIndex(pc => pc.Number);
            builder.HasIndex(pc => pc.CurrencyCode);
            builder.HasIndex(pc => pc.ActivationDate);
            builder.HasIndex(pc => pc.ExpirationDate);

            builder.Property(pc => pc.DiscountFlatRate).HasColumnType("decimal(19, 4)");
            builder.Property(pc => pc.MaxPromoAmount).HasColumnType("decimal(19, 4)");
        }
    }
}
