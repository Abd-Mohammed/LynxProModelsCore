using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class DeviceMessageConfiguration : IEntityTypeConfiguration<DeviceMessage>
    {
        public void Configure(EntityTypeBuilder<DeviceMessage> builder)
        {
            builder.HasIndex(dm => dm.Sid);
            builder.HasIndex(dm => dm.Status);
            builder.HasIndex(dm => dm.VehicleName);
            builder.HasIndex(dm => dm.VehiclePlateNo);
        }
    }
}
