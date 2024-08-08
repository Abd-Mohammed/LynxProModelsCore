
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class PoiRemark : TenantAware, ITenantAware
    {
        public int PoiRemarkId { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Text", Description = "POI Remark Text")]
        public string Text { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "POI Remark Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "POI Remark Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "POI Remark Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "POI Remark Modified Date")]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "Vehicle", Description = "Vehicle Id")]
        public int VehicleId { get; set; }

        [Display(Name = "POI", Description = "POI Id")]
        public int PoiId { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual Poi Poi { get; set; }
    }
}