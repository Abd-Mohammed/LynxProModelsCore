using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class TrackedItemGroupConfiguration : IEntityTypeConfiguration<TrackedItemGroup>
    {
        public void Configure(EntityTypeBuilder<TrackedItemGroup> builder)
        {
            builder.HasIndex(tig => tig.Name);
        }
    }
}
