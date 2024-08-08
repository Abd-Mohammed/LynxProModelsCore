using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class DriverHosConfiguration : IEntityTypeConfiguration<DriverHos>
    {
        public void Configure(EntityTypeBuilder<DriverHos> builder)
        {
            builder.ToTable("DriverHoses");

            builder.HasKey(dhos => dhos.DriverId);
            builder.HasOne(dhos => dhos.Driver)
                   .WithOne(d => d.DriverHos)
                   .HasForeignKey<DriverHos>(dhos => dhos.DriverId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(dhos => dhos.Status)
                   .WithMany()
                   .HasForeignKey(dhos => dhos.StatusId);

            builder.HasOne(dhos => dhos.Vehicle)
                   .WithMany()
                   .HasForeignKey(dhos => dhos.VehicleId);
        }
    }
}
