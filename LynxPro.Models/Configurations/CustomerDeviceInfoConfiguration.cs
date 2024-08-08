using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class CustomerDeviceInfoConfiguration : IEntityTypeConfiguration<CustomerDeviceInfo>
    {
        public void Configure(EntityTypeBuilder<CustomerDeviceInfo> builder)
        {
            // Primary key
            builder.HasKey(cdi => cdi.CustomerId);

            builder.HasIndex(cdi => cdi.Platform);
            builder.HasIndex(cdi => cdi.Idiom);

            builder.HasOne(cdi => cdi.Customer)
                   .WithOne(c => c.DeviceInfo)
                   .HasForeignKey<CustomerDeviceInfo>(cdi => cdi.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
