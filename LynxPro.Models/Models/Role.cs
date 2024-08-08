
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class Role : TenantAware, ITenantAware
    {
        public Role()
        {
            RolePermissions = new HashSet<RolePermission>();
            UserRoles = new HashSet<UserRole>();
        }

        public int RoleId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Role Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Description", Description = "Role Description")]
        public string Description { get; set; }

        [Display(Name = "Is Sys Admin", Description = "Is System Admin")]
        public bool IsSystemAdmin { get; set; }

        [Display(Name = "Is Fixed", Description = "Is Role Fixed")]
        public bool IsFixed { get; set; }

        [Display(Name = "Is Franchise", Description = "Is Franchise")]
        public bool IsFranchise { get; set; }

        [Display(Name = "Franchise Id", Description = "Franchise Id")]
        public int? FranchiseId { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}