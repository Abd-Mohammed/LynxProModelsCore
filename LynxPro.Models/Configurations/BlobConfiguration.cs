using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class BlobConfiguration : IEntityTypeConfiguration<Blob>
    {
        public void Configure(EntityTypeBuilder<Blob> builder)
        {
            builder.HasIndex(b => b.Name).IsUnique();

            builder.Property(p => p.CreatedDate).HasColumnType("datetime");
            builder.Property(p => p.ModifiedDate).HasColumnType("datetime");
        }
    }
}
