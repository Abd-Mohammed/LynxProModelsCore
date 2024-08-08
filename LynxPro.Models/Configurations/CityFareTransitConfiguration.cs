using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class CityFareTransitConfiguration : IEntityTypeConfiguration<CityFareTransit>
    {
        public void Configure(EntityTypeBuilder<CityFareTransit> builder)
        {
            builder.Property(cfec => cfec.Fee).HasColumnType("decimal(19, 4)");

            builder.HasOne(cfec => cfec.City)
                   .WithMany()
                   .HasForeignKey(cfec => cfec.CityId)
                   .OnDelete(DeleteBehavior.ClientSetNull); // Assuming optional with a non-cascade delete

            builder.HasOne(cfec => cfec.CityFare)
                   .WithMany(cf => cf.Transits)
                   .HasForeignKey(cfec => cfec.CityFareId)
                   .OnDelete(DeleteBehavior.Cascade); // Assuming cascade delete
        }
    }
}
