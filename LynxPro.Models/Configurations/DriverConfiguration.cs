using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.HasIndex(d => d.StaffId);
            builder.HasIndex(d => d.Username);
            builder.HasIndex(d => d.MobileNo);
            builder.HasIndex(d => d.Email);
        }
    }
}
