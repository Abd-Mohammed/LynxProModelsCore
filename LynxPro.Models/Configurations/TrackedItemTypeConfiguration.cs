using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class TrackedItemTypeConfiguration : IEntityTypeConfiguration<TrackedItemType>
    {
        public void Configure(EntityTypeBuilder<TrackedItemType> builder)
        {
            builder.HasIndex(tit => tit.Name);
        }
    }
}
