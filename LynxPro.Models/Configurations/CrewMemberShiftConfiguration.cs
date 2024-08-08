using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class CrewMemberShiftConfiguration : IEntityTypeConfiguration<CrewMemberShift>
    {
        public void Configure(EntityTypeBuilder<CrewMemberShift> builder)
        {
            // Composite key
            builder.HasKey(ds => new { ds.CrewMemberId, ds.ShiftId });

            builder.HasOne(ds => ds.CrewMember)
                   .WithMany(d => d.CrewMemberShifts)
                   .HasForeignKey(ds => ds.CrewMemberId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ds => ds.Shift)
                   .WithMany()
                   .HasForeignKey(ds => ds.ShiftId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
