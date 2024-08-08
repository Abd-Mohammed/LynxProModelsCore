using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class ActiveAlertActivityConfiguration : IEntityTypeConfiguration<ActiveAlertActivity>
    {
        public void Configure(EntityTypeBuilder<ActiveAlertActivity> builder)
        {
            builder.HasOne(aaa => aaa.Alert)
                   .WithMany(aa => aa.AlertActivities)
                   .HasForeignKey(aaa => aaa.AlertId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}