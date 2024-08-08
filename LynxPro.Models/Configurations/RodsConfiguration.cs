using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class RodsConfiguration : IEntityTypeConfiguration<Rods>
    {
        public void Configure(EntityTypeBuilder<Rods> builder)
        {
            builder.ToTable("Rodses");
        }
    }
}
