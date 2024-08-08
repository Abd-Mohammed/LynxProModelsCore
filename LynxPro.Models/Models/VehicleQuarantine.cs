using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class VehicleQuarantine : TenantAware, ITenantAware
    {
        public int VehicleId { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Start Time", Description = "Vehicle Quarantine Start Time")]
        public DateTime StartTime { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "End Time", Description = "Vehicle Quarantine End Time")]
        public DateTime EndTime { get; set; }

        [Range(1, 10000)]
        [Display(Name = " Radius", Description = "Vehicle Quarantine Radius")]
        public int Radius { get; set; }

        [Display(Name = "Is Enabled", Description = "Is Vehicle Quarantine Enabled")]
        public bool IsEnabled { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Vehicle Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Vehicle Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Vehicle Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Vehicle Modified Date")]
        public DateTime ModifiedDate { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}