using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class VehicleQuarantineLog : TenantAware, ITenantAware
    {
        public int VehicleQuarantineLogId { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Time", Description = "Vehicle Quarantine Log Time")]
        public DateTime Time { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Vehicle Quarantine Log Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(25)]
        [Display(Name = "Plate No", Description = "Vehicle Quarantine Log Plate No")]
        public string PlateNo { get; set; }

        [MaxLength(10)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Staff Id", Description = "Driver Staff Id")]
        [RegularExpression("[a-zA-Z0-9]{5,10}", ErrorMessage = "The field {0} is invalid.")]
        public string DriverStaffId { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Start Time", Description = "Vehicle Quarantine Log Start Time")]
        public DateTime StartTime { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "End Time", Description = "Vehicle Quarantine Log End Time")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Was Activated", Description = "Was Vehicle Quarantine Log Activated")]
        public bool WasActivated { get; set; }

        [Display(Name = "Was Breached", Description = "Was Vehicle Quarantine Log Breached")]
        public bool WasBreached { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Vehicle Quarantine Log Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Vehicle Quarantine Log Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Vehicle Quarantine Log Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Vehicle Quarantine Log Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}