using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class AlertActivityConfiguration : IEntityTypeConfiguration<AlertActivity>
    {
        public void Configure(EntityTypeBuilder<AlertActivity> builder)
        {
            builder.Property(p => p.Time).HasColumnType("datetime");
        }
    }
}
