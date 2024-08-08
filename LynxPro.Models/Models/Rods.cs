
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public enum RodsOriginType
    {
        [Display(Name = "Automatic")]
        Automatic = 1,
        [Display(Name = "Driver")]
        Driver = 2
    }

    public class Rods : TenantAware, ITenantAware
    {
        public int RodsId { get; set; }

        [Display(Name = "HOS Status", Description = "Hos Status Id")]
        public int HosStatusId { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Time", Description = "RODS Time")]
        public DateTime Time { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Location", Description = "RODS Location")]
        public string Location { get; set; }

        [Display(Name = "Odometer (m)", Description = "RODS Odometer (m)")]
        public long Odometer { get; set; }

        [Display(Name = "Engine Hours", Description = "RODS Engine Hours")]
        public double EngineHours { get; set; }

        [Display(Name = "Duration", Description = "RODS Duration")]
        public long Duration { get; set; }

        [MaxLength(50)]
        [Display(Name = "Annotation", Description = "RODS Annotation")]
        public string Annotation { get; set; }

        [Display(Name = "Is Ruleset Violated", Description = "Is Ruleset Violated")]
        public bool IsRulesetViolated { get; set; }

        [MaxLength(250)]
        [Display(Name = "Advisory Message", Description = "RODS Advisory Message")]
        public string AdvisoryMessage { get; set; }

        [Range(1, 2)]
        [Display(Name = "Origin", Description = "RODS Origin")]
        public RodsOriginType Origin { get; set; }

        [MaxLength(50)]
        [Display(Name = "Assigned By", Description = "Vehicle Assigned By")]
        public string AssignedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        public DateTime? AssignedDate { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        public DateTime? VerifiedDate { get; set; }

        [Display(Name = "Driver", Description = "Driver Id")]
        public int? DriverId { get; set; } // Unclaimed

        [Display(Name = "Vehicle", Description = "Vehicle Id")]
        public int VehicleId { get; set; }

        [Display(Name = "Is Processed", Description = "Is RODS Processed")]
        public bool IsProcessed { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual HosStatus HosStatus { get; set; }
    }
}