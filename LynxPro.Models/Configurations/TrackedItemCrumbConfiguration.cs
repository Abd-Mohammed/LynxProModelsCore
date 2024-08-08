using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class TrackedItemCrumbConfiguration : IEntityTypeConfiguration<TrackedItemCrumb>
    {
        public void Configure(EntityTypeBuilder<TrackedItemCrumb> builder)
        {
            builder.HasIndex(tic => tic.TimeStamp);

            builder.Property(p => p.TimeStamp)
                   .HasColumnType("datetime");

            builder.Property(p => p.ServerTimestamp)
                   .HasColumnType("datetime");
        }
    }
}
