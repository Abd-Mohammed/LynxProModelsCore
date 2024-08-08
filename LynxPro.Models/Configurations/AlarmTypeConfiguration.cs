using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class AlarmTypeConfiguration : IEntityTypeConfiguration<AlarmType>
    {
        public void Configure(EntityTypeBuilder<AlarmType> builder)
        {
            builder.HasIndex(at => at.Name).IsUnique();
            builder.HasIndex(at => at.Code).IsUnique();
        }
    }
}
