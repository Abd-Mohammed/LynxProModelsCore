using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class ScoreMetricConfiguration : IEntityTypeConfiguration<ScoreMetric>
    {
        public void Configure(EntityTypeBuilder<ScoreMetric> builder)
        {
            builder.Property(sm => sm.CostImplication)
                   .HasColumnType("decimal(19, 4)");
        }
    }
}
