using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LynxPro.Models.Configurations
{
    public class PermissionShortcutLinkConfiguration : IEntityTypeConfiguration<PermissionShortcutLink>
    {
        public void Configure(EntityTypeBuilder<PermissionShortcutLink> builder)
        {
            builder.HasOne(pls => pls.Parent)
                   .WithMany(pls => pls.Children)
                   .HasForeignKey(pls => pls.ParentId)
                   .IsRequired(false);
        }
    }
}
