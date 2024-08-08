using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class DriverGroupItemConfiguration : IEntityTypeConfiguration<DriverGroupItem>
    {
        public void Configure(EntityTypeBuilder<DriverGroupItem> builder)
        {
            // Composite key
            builder.HasKey(dgi => new { dgi.DriverGroupId, dgi.DriverId });

            // Cascade delete
            builder.HasOne(dgi => dgi.Driver)
                   .WithMany()
                   .HasForeignKey(dgi => dgi.DriverId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(dgi => dgi.DriverGroup)
                   .WithMany()
                   .HasForeignKey(dgi => dgi.DriverGroupId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
