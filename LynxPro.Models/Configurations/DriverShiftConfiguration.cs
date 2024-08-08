using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class DriverShiftConfiguration : IEntityTypeConfiguration<DriverShift>
    {
        public void Configure(EntityTypeBuilder<DriverShift> builder)
        {
            // Composite key
            builder.HasKey(ds => new { ds.DriverId, ds.ShiftId });

            builder.HasOne(ds => ds.Driver)
                   .WithMany(d => d.DriverShifts)
                   .HasForeignKey(ds => ds.DriverId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ds => ds.Shift)
                   .WithMany()
                   .HasForeignKey(ds => ds.ShiftId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
