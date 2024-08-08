using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class ActShiftBreakConfiguration : IEntityTypeConfiguration<ActShiftBreak>
    {
        public void Configure(EntityTypeBuilder<ActShiftBreak> builder)
        {
            builder.Property(p => p.StartTime).HasColumnType("datetime");
            builder.Property(p => p.EndTime).HasColumnType("datetime");
        }
    }
}
