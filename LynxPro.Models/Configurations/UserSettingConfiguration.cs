using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class UserSettingConfiguration : IEntityTypeConfiguration<UserSetting>
    {
        public void Configure(EntityTypeBuilder<UserSetting> builder)
        {
            // One to one relation
            builder.HasKey(us => us.UserId);

            builder.HasOne(us => us.User)
                   .WithOne(u => u.UserSetting)
                   .HasForeignKey<UserSetting>(us => us.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
