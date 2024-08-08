using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class ActiveAlertBlobConfiguration : IEntityTypeConfiguration<ActiveAlertBlob>
    {
        public void Configure(EntityTypeBuilder<ActiveAlertBlob> builder)
        {
            builder.HasOne(aaa => aaa.Alert)
                   .WithMany(aa => aa.AlertBlobs)
                   .HasForeignKey(aaa => aaa.AlertId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
