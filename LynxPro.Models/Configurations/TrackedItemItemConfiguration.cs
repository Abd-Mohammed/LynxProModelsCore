using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class TrackedItemItemConfiguration : IEntityTypeConfiguration<TrackedItemItem>
    {
        public void Configure(EntityTypeBuilder<TrackedItemItem> builder)
        {
            builder.HasKey(tii => new { tii.TrackedItemGroupId, tii.TrackedItemId });

            builder.HasOne(tii => tii.TrackedItem)
                   .WithMany()
                   .HasForeignKey(tii => tii.TrackedItemId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(tii => tii.TrackedItemGroup)
                   .WithMany() 
                   .HasForeignKey(tii => tii.TrackedItemGroupId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
