using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class RestrictedPudoLocationConfiguration : IEntityTypeConfiguration<RestrictedPudoLocation>
    {
        public void Configure(EntityTypeBuilder<RestrictedPudoLocation> builder)
        {
            builder.HasKey(rp => new { rp.VehicleTypeId, rp.PudoLocationId });
        }
    }
}
