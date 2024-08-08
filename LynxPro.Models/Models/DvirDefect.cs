
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class DvirDefect : TenantAware, ITenantAware
    {
        public int DvirDefectId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Category", Description = "Vehicle DVIR Defect Category")]
        public string Category { get; set; }

        [Required]
        [Display(Name = "Details", Description = "Vehicle DVIR Defect Details")]
        public string Details { get; set; }

        [Display(Name = "DVIR", Description = "DVIR Id")]
        public int DvirId { get; set; }

        public virtual Dvir Dvir { get; set; }
    }
}