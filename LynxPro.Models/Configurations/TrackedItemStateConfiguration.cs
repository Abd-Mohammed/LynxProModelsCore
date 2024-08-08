using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class TrackedItemStateConfiguration : IEntityTypeConfiguration<TrackedItemState>
    {
        public void Configure(EntityTypeBuilder<TrackedItemState> builder)
        {
            builder.HasKey(tis => tis.TrackedItemId);

            builder.HasOne(tis => tis.TrackedItem)
                   .WithOne(b => b.TrackedItemState)
                   .HasForeignKey<TrackedItemState>(tis => tis.TrackedItemId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
