
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class PermissionShortcutLink : TenantAware, ITenantAware
    {
        public PermissionShortcutLink()
        {
            Children = new HashSet<PermissionShortcutLink>();
        }

        public int PermissionShortcutLinkId { get; set; }

        [MaxLength(50)]
        [Display(Name = "Name", Description = "Permission Shortcut Link Name")]
        public string Name { get; set; }

        [Display(Name = "Permission", Description = "Permission Id")]
        public int? PermissionId { get; set; }

        [Display(Name = "Parent", Description = "Parent Id")]
        public int? ParentId { get; set; }

        public virtual Permission Permission { get; set; }
        public virtual PermissionShortcutLink Parent { get; set; }
        public virtual ICollection<PermissionShortcutLink> Children { get; set; }
    }
}