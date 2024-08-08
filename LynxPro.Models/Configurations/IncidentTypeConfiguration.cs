using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class IncidentTypeConfiguration : IEntityTypeConfiguration<IncidentType>
    {
        public void Configure(EntityTypeBuilder<IncidentType> builder)
        {
            // Optional relationship with cascade delete
            builder.HasOne(inc => inc.Parent)
                   .WithMany(inc => inc.Children)
                   .HasForeignKey(inc => inc.ParentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
