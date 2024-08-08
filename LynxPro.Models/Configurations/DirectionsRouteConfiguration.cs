using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class DirectionsRouteConfiguration : IEntityTypeConfiguration<DirectionsRoute>
    {
        public void Configure(EntityTypeBuilder<DirectionsRoute> builder)
        {
            builder.HasIndex(dr => dr.Number);
            builder.HasIndex(dr => dr.Status);
            builder.HasIndex(dr => dr.WorkflowStatus);
            builder.HasIndex(dr => dr.StartDate);
            builder.HasIndex(dr => dr.EndDate);
            builder.HasIndex(dr => dr.ActStartDate);
            builder.HasIndex(dr => dr.ActEndDate);
        }
    }
}
