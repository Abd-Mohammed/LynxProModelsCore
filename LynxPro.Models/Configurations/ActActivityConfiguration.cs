using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class ActActivityConfiguration : IEntityTypeConfiguration<ActActivity>
    {
        public void Configure(EntityTypeBuilder<ActActivity> builder)
        {
            builder.HasOne(aa => aa.ChildActivity)
                   .WithMany()
                   .HasForeignKey(aa => aa.ChildActivityId)
                   .IsRequired(false);

            builder.Property(p => p.ArrTime2).HasColumnType("datetime");
            builder.Property(p => p.EndTime2).HasColumnType("datetime");
            builder.Property(p => p.EventTime).HasColumnType("datetime");

            builder.Property(p => p.ArrTime2).HasColumnType("datetime");
            builder.Property(p => p.EndTime2).HasColumnType("datetime");
            builder.Property(p => p.EventTime).HasColumnType("datetime");
        }
    }
}
