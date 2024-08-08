using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class CityFareConfiguration : IEntityTypeConfiguration<CityFare>
    {
        public void Configure(EntityTypeBuilder<CityFare> builder)
        {
            builder.HasIndex(cf => cf.CurrencyCode);

            builder.Property(cf => cf.CostPerMinute).HasColumnType("decimal(19, 4)");
            builder.Property(cf => cf.CostPerDistance).HasColumnType("decimal(19, 4)");
            builder.Property(cf => cf.BaseFare).HasColumnType("decimal(19, 4)");
            builder.Property(cf => cf.MinimumFare).HasColumnType("decimal(19, 4)");
            builder.Property(cf => cf.BookingFee).HasColumnType("decimal(19, 4)");
            builder.Property(cf => cf.WaitTimeChargePerMinute).HasColumnType("decimal(19, 4)");
        }
    }
}
