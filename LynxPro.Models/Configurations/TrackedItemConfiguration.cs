using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class TrackedItemConfiguration : IEntityTypeConfiguration<TrackedItem>
    {
        public void Configure(EntityTypeBuilder<TrackedItem> builder)
        {
            builder.HasIndex(ti => ti.Name);

            builder.HasOne(ti => ti.TrackedItemType)
                   .WithMany()
                   .HasForeignKey(ti => ti.TrackedItemTypeId);

            builder.HasOne(ti => ti.Device)
                   .WithMany(d => d.TrackedItems)
                   .HasForeignKey(ti => ti.DeviceId)
                   .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
