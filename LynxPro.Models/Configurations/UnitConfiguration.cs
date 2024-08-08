using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.HasIndex(u => u.TrackingNo);
            builder.HasIndex(u => u.Type);
            builder.HasIndex(u => u.Status);

            builder.HasOne(u => u.Activity)
                   .WithMany()
                   .HasForeignKey(u => u.ActivityId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
