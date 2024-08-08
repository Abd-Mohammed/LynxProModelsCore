using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class RideConfiguration : IEntityTypeConfiguration<Ride>
    {
        public void Configure(EntityTypeBuilder<Ride> builder)
        {
            builder.HasIndex(r => r.Code);
            builder.HasIndex(r => r.Status);
            builder.HasIndex(r => r.PickupTime);
            builder.HasIndex(r => r.DropoffTime);
            builder.HasIndex(r => r.ExpectedFareCurrencyCode);
            builder.HasIndex(r => r.FareCurrencyCode);
            builder.HasIndex(r => r.LastStatusUpdatedTime);
            builder.HasIndex(r => r.CancelReasonCode);
            builder.HasIndex(r => r.PromoCodeNumber);

            builder.HasOne(r => r.Request)
                   .WithMany()
                   .HasForeignKey(r => r.RequestId)
                   .IsRequired(false);

            builder.Property(r => r.ExpectedDiscount).HasColumnType("decimal(19,4)");
            builder.Property(r => r.ExpectedFare).HasColumnType("decimal(19,4)");
            builder.Property(r => r.Discount).HasColumnType("decimal(19,4)");
            builder.Property(r => r.NetFare).HasColumnType("decimal(19,4)");
            builder.Property(r => r.TotalFare).HasColumnType("decimal(19,4)");
        }
    }
}
