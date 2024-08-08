using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class DriverSettingConfiguration : IEntityTypeConfiguration<DriverSetting>
    {
        public void Configure(EntityTypeBuilder<DriverSetting> builder)
        {
            // One to one relation
            builder.HasKey(ds => ds.DriverId);

            builder.HasOne(ds => ds.Driver)
                   .WithOne(d => d.DriverSetting)
                   .HasForeignKey<DriverSetting>(ds => ds.DriverId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
