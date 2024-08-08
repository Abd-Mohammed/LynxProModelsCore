
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class DirectionsActivityResult : TenantAware, ITenantAware
    {
        public int DirectionsActivityResultId { get; set; }

        [Required]
        [MaxLength(10)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Code", Description = "Activity Result Code")]
        public string Code { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Activity Result Name")]
        public string Name { get; set; }

        [MaxLength(250)]
        [Display(Name = "Description", Description = "Activity Result Description")]
        public string Description { get; set; }
    }
}