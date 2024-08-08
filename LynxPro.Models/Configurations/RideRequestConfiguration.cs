using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class RideRequestConfiguration : IEntityTypeConfiguration<RideRequest>
    {
        public void Configure(EntityTypeBuilder<RideRequest> builder)
        {
            builder.HasIndex(rr => rr.Code);
            builder.HasIndex(rr => rr.Status);
            builder.HasIndex(rr => rr.PickupTime);
            builder.HasIndex(rr => rr.DropoffTime);
            builder.HasIndex(rr => rr.FareCurrencyCode);
            builder.HasIndex(rr => rr.PromoCode);
            builder.HasIndex(rr => rr.LastStatusUpdatedTime);

            builder.Property(rr => rr.Fare).HasColumnType("decimal(19,4)");
            builder.Property(rr => rr.Discount).HasColumnType("decimal(19,4)");

            builder.HasOne(rr => rr.Parent)
                   .WithMany(rr => rr.Children)
                   .HasForeignKey(rr => rr.ParentId)
                   .IsRequired(false);
        }
    }
}
