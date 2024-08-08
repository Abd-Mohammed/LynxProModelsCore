using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class DvirConfiguration : IEntityTypeConfiguration<Dvir>
    {
        public void Configure(EntityTypeBuilder<Dvir> builder)
        {
            builder.ToTable("Dvirs");

            builder.HasOne(d => d.InspectedBy)
                   .WithMany()
                   .HasForeignKey(d => d.InspectedById);
        }
    }
}
