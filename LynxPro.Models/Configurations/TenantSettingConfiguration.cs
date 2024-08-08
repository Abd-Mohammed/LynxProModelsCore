using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class TenantSettingConfiguration : IEntityTypeConfiguration<TenantSetting>
    {
        public void Configure(EntityTypeBuilder<TenantSetting> builder)
        {
            builder.ToTable("TenantSettings");

            builder.HasIndex(ta => ta.Name).IsUnique();
            builder.HasIndex(ta => ta.DisplayName);
        }
    }
}
