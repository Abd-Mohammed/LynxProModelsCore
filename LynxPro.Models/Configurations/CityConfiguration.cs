using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasIndex(c => c.Name);

            builder.HasOne(c => c.Parent)
                   .WithMany()
                   .HasForeignKey(c => c.ParentId)
                   .IsRequired(false);
        }
    }
}
