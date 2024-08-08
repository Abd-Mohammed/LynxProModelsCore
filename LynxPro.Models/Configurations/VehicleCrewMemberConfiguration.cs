using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class VehicleCrewMemberConfiguration : IEntityTypeConfiguration<VehicleCrewMember>
    {
        public void Configure(EntityTypeBuilder<VehicleCrewMember> builder)
        {
            // Composite key
            builder.HasKey(vcm => new { vcm.VehicleId, vcm.CrewMemberId });

            builder.HasOne(vcm => vcm.Vehicle)
                   .WithMany(v => v.VehicleCrewMembers)
                   .HasForeignKey(vcm => vcm.VehicleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(vcm => vcm.CrewMember)
                   .WithMany()
                   .HasForeignKey(vcm => vcm.CrewMemberId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
