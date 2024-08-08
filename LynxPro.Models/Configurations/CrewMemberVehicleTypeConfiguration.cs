using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class CrewMemberVehicleTypeConfiguration : IEntityTypeConfiguration<CrewMemberVehicleType>
    {
        public void Configure(EntityTypeBuilder<CrewMemberVehicleType> builder)
        {
            // Composite key
            builder.HasKey(cvt => new { cvt.CrewMemberId, cvt.VehicleTypeId });

            builder.HasOne(cvt => cvt.CrewMember)
                   .WithMany(c => c.CrewMemberVehicleTypes)
                   .HasForeignKey(cvt => cvt.CrewMemberId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cvt => cvt.VehicleType)
                   .WithMany()
                   .HasForeignKey(cvt => cvt.VehicleTypeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
