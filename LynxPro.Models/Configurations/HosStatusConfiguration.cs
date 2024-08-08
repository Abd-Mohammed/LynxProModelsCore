using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class HosStatusConfiguration : IEntityTypeConfiguration<HosStatus>
    {
        public void Configure(EntityTypeBuilder<HosStatus> builder)
        {
            builder.ToTable("HosStatuses");

            builder.HasIndex(hs => hs.Acronym).IsUnique();
            builder.HasIndex(hs => hs.Description).IsUnique();
        }
    }
}
