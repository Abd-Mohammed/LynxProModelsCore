using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class VehicleQuarantineConfiguration : IEntityTypeConfiguration<VehicleQuarantine>
    {
        public void Configure(EntityTypeBuilder<VehicleQuarantine> builder)
        {
            // Primary key
            builder.HasKey(vs => vs.VehicleId);

            builder.HasOne(vs => vs.Vehicle)
                   .WithOne(v => v.VehicleQuarantine)
                   .HasForeignKey<VehicleQuarantine>(vs => vs.VehicleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
