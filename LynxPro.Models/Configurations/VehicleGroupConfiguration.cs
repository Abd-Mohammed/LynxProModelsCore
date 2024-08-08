using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class VehicleGroupConfiguration : IEntityTypeConfiguration<VehicleGroup>
    {
        public void Configure(EntityTypeBuilder<VehicleGroup> builder)
        {
            builder.HasIndex(vg => vg.Name);
        }
    }
}
