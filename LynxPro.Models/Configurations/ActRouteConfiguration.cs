using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class ActRouteConfiguration : IEntityTypeConfiguration<ActRoute>
    {
        public void Configure(EntityTypeBuilder<ActRoute> builder)
        {
            builder.HasOne(ar => ar.Driver)
                   .WithMany()
                   .HasForeignKey(ar => ar.DriverId)
                   .IsRequired(false);

            builder.Property(p => p.StartTime).HasColumnType("datetime");
            builder.Property(p => p.EndTime).HasColumnType("datetime");
        }
    }
}
