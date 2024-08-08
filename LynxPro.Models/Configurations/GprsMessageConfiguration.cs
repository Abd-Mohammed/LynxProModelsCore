using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class GprsMessageConfiguration : IEntityTypeConfiguration<GprsMessage>
    {
        public void Configure(EntityTypeBuilder<GprsMessage> builder)
        {
            builder.HasIndex(gm => gm.Sid);
        }
    }
}
