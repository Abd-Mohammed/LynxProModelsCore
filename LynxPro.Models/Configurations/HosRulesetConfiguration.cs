using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class HosRulesetConfiguration : IEntityTypeConfiguration<HosRuleset>
    {
        public void Configure(EntityTypeBuilder<HosRuleset> builder)
        {
            builder.HasIndex(hrs => hrs.Name);
            builder.HasIndex(hrs => hrs.Cycle);
        }
    }
}
