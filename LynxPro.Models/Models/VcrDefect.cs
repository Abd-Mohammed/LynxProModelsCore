using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class VcrDefect : TenantAware, ITenantAware
    {
        public int VcrDefectId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Category", Description = "VCR Defect Category")]
        public string Category { get; set; }

        [Required]
        [Display(Name = "Details", Description = "VCR Defect Details")]
        public string Details { get; set; }

        [Display(Name = "VCR", Description = "VCR Id")]
        public int VcrId { get; set; }

        public virtual Vcr Vcr { get; set; }
    }
}