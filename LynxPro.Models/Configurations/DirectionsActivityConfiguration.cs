using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class DirectionsActivityConfiguration : IEntityTypeConfiguration<DirectionsActivity>
    {
        public void Configure(EntityTypeBuilder<DirectionsActivity> builder)
        {
            builder.HasIndex(du => du.Index);
            builder.HasIndex(du => du.StopIndex);
            builder.HasIndex(du => du.ArrDateTime);
            builder.HasIndex(du => du.EndDateTime);
            builder.HasIndex(du => du.ActArrDateTime);
            builder.HasIndex(du => du.ActEndDateTime);
            builder.HasIndex(du => du.Status);

            builder.HasOne(du => du.Unit)
                   .WithMany()
                   .HasForeignKey(du => du.UnitId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(du => du.Parent)
                   .WithMany()
                   .HasForeignKey(du => du.ParentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
