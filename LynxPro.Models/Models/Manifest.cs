
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class Manifest : TenantAware, ITenantAware
    {
        public int ManifestId { get; set; }

        [Required]
        [MaxLength(25)]
        [Display(Name = "Number", Description = "Manifest Number")]
        public string Number { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Driver Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Driver Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Driver Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Driver Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}