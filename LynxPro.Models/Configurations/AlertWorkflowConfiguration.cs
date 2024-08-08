using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class AlertWorkflowConfiguration : IEntityTypeConfiguration<AlertWorkflow>
    {
        public void Configure(EntityTypeBuilder<AlertWorkflow> builder)
        {
        }
    }
}
