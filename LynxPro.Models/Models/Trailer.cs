using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class Trailer : TenantAware, ITenantAware
    {
        public int TrailerId { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Name", Description = "Trailer Name")]
        public string Name { get; set; }

        [Display(Name = "Manifest", Description = "Manifest Id")]
        public int? ManifestId { get; set; }

        [Display(Name = "Vehicle", Description = "Vehicle Id")]
        public int? VehicleId { get; set; }

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

        public virtual Manifest Manifest { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}