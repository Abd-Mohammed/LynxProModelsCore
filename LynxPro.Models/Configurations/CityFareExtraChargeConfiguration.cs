using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class CityFareExtraChargeConfiguration : IEntityTypeConfiguration<CityFareExtraCharge>
    {
        public void Configure(EntityTypeBuilder<CityFareExtraCharge> builder)
        {
            builder.Property(cfec => cfec.Fee).HasColumnType("decimal(19, 4)");

            builder.HasOne(cfec => cfec.CityFare)
                   .WithMany(cf => cf.ExtraCharges)
                   .HasForeignKey(cfec => cfec.CityFareId);
        }
    }
}
