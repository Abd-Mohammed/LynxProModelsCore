
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class PoiGroup : TenantAware, ITenantAware
    {
        public int PoiGroupId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "POI Group Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "POI Group Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "POI Group Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "POI Group Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "POI Group Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}