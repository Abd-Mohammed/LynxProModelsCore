using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class ActShiftConfiguration : IEntityTypeConfiguration<ActShift>
    {
        public void Configure(EntityTypeBuilder<ActShift> builder)
        {
            builder.Property(p => p.StartTime).HasColumnType("datetime");
            builder.Property(p => p.EndTime).HasColumnType("datetime");
        }
    }
}
