using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class Permission
    {
        public Permission()
        {
            RolePermissions = new HashSet<RolePermission>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PermissionId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Description", Description = "Permission Description")]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Code", Description = "Permission Code")]
        public string Code { get; set; }

        [MaxLength(50)]
        [Display(Name = "Icon", Description = "Permission Icon")]
        public string Icon { get; set; }

        [MaxLength(100)]
        [Display(Name = "Link", Description = "Permission Link")]
        public string Link { get; set; }

        [Display(Name = "Is Multi SaaS", Description = "Is Permission Multi SaaS")]
        public bool IsMultiSaas { get; set; }

        [Display(Name = "Is Franchise")]
        public bool IsFranchise { get; set; }

        [Display(Name = "Permission Area", Description = "Permission Area Id")]
        public int PermissionAreaId { get; set; }

        public virtual PermissionArea PermissionArea { get; set; }
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}