using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class PermissionArea
    {
        public PermissionArea()
        {
            Permissions = new HashSet<Permission>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PermissionAreaId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Description", Description = "Permission Area Description")]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Code", Description = "Permission Area Code")]
        public string Code { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Icon", Description = "Permission Area Icon")]
        public string Icon { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Link", Description = "Permission Area Link")]
        public string Link { get; set; }

        [Display(Name = "Number", Description = "Permission Area Number")]
        public int Number { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}