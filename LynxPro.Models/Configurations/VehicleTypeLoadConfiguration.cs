using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class VehicleTypeLoadConfiguration : IEntityTypeConfiguration<VehicleTypeLoad>
    {
        public void Configure(EntityTypeBuilder<VehicleTypeLoad> builder)
        {
            // Primary key
            builder.HasKey(vtl => vtl.VehicleTypeId);

            builder.HasOne(vtl => vtl.VehicleType)
                   .WithOne(vt => vt.Load)
                   .HasForeignKey<VehicleTypeLoad>(vtl => vtl.VehicleTypeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
