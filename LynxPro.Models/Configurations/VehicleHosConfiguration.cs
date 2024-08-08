using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class VehicleHosConfiguration : IEntityTypeConfiguration<VehicleHos>
    {
        public void Configure(EntityTypeBuilder<VehicleHos> builder)
        {
            builder.ToTable("VehicleHoses");

            builder.HasKey(vh => vh.VehicleId);
            builder.HasOne(vh => vh.Vehicle)
                   .WithOne(v => v.VehicleHos)
                   .HasForeignKey<VehicleHos>(vh => vh.VehicleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(vh => vh.Status)
                   .WithMany()
                   .HasForeignKey(vh => vh.StatusId);
        }
    }
}
