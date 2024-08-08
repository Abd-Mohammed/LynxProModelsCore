using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class VehicleFranchiseConfiguration : IEntityTypeConfiguration<VehicleFranchise>
    {
        public void Configure(EntityTypeBuilder<VehicleFranchise> builder)
        {
            builder.HasIndex(vf => vf.Name);
        }
    }
}
