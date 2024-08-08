using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class AreaGroupConfiguration : IEntityTypeConfiguration<AreaGroup>
    {
        public void Configure(EntityTypeBuilder<AreaGroup> builder)
        {
            builder.HasIndex(ag => ag.Name);
        }
    }
}
