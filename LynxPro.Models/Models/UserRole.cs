using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class UserRole : TenantAware, ITenantAware
    {
        [Display(Name = "User", Description = "User Id")]
        public int UserId { get; set; }

        [Display(Name = "Role", Description = "Role Id")]
        public int RoleId { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}