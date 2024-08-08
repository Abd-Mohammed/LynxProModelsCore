
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class RolePermission : TenantAware, ITenantAware
    {
        [Display(Name = "Role", Description = "Role Id")]
        public int RoleId { get; set; }

        [Display(Name = "Permission", Description = "Permission Id")]
        public int PermissionId { get; set; }

        public virtual Role Role { get; set; }
        public virtual Permission Permission { get; set; }
    }
}