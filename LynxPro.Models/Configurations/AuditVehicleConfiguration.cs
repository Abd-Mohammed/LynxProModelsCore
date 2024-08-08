using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class AuditVehicleConfiguration : IEntityTypeConfiguration<AuditVehicle>
    {
        public void Configure(EntityTypeBuilder<AuditVehicle> builder)
        {
            builder.ToTable("AuditVehicles");
        }
    }
}
