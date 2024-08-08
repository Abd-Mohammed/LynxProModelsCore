
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class DriverHos : TenantAware, ITenantAware
    {
        public int DriverId { get; set; }

        [Display(Name = "Cycle (sec)", Description = "Driver HOS Cycle (sec)")]
        public long Cycle { get; set; }

        [Display(Name = "Cycle Left (sec)", Description = "Driver HOS Cycle Left (sec)")]
        public long CycleLeft { get; set; }

        [Display(Name = "Is Cycle Rule Violated", Description = "Is Driver HOS Cycle Rule Violated")]
        public bool IsCycleRuleViolated { get; set; }

        [Display(Name = "Duty (sec)", Description = "Driver HOS Duty (sec)")]
        public long Duty { get; set; }

        [Display(Name = "Duty Left (sec)", Description = "Driver HOS Duty Left (sec)")]
        public long DutyLeft { get; set; }

        [Display(Name = "Is Duty Rule Violated", Description = "Is Driver HOS Duty Rule Violated")]
        public bool IsDutyRuleViolated { get; set; }

        [Display(Name = "Driving (sec)", Description = "Driver HOS Driving (sec)")]
        public long Driving { get; set; }

        [Display(Name = "Driving Left (sec)", Description = "Driver HOS Driving Left (sec)")]
        public long DrivingLeft { get; set; }

        [Display(Name = "Is Driving Rule Violated", Description = "Is Driver HOS Driving Rule Violated")]
        public bool IsDrivingRuleViolated { get; set; }

        [Display(Name = "Consecutive Driving (sec)", Description = "Driver HOS Consecutive Driving (sec)")]
        public long ConsecutiveDriving { get; set; }

        [Display(Name = "Consecutive Driving Left (sec)", Description = "Driver HOS Consecutive Driving Left (sec)")]
        public long ConsecutiveDrivingLeft { get; set; }

        [Display(Name = "Is Consecutive Driving Rule Violated", Description = "Is Driver HOS Consecutive Driving Rule Violated")]
        public bool IsConsecutiveDrivingRuleViolated { get; set; }

        [Display(Name = "Consecutive OFF/SB (sec)", Description = "Consecutive OFF/SB (sec)")]
        public long ConsecutiveOffOrSb { get; set; }

        [Display(Name = "Rest In", Description = "Driver HOS Rest In")]
        public long RestIn { get; set; }

        [Range(0, 100)]
        [Display(Name = "Remaining", Description = "Driver HOS Remaining")]
        public double Remaining { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Time", Description = "RODS Time")]
        public DateTime Time { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Location", Description = "Driver HOS Location")]
        public string Location { get; set; }

        [Display(Name = "Odometer (m)", Description = "Driver HOS Odometer (m)")]
        public long Odometer { get; set; }

        [Display(Name = "Engine Hours", Description = "Driver HOS Engine Hours")]
        public double EngineHours { get; set; }

        [MaxLength(250)]
        [Display(Name = "Advisory Message", Description = "Driver HOS Advisory Message")]
        public string AdvisoryMessage { get; set; }

        [Display(Name = "Status", Description = "Status Id")]
        public int StatusId { get; set; }

        [Display(Name = "Vehicle", Description = "Vehicle Id")]
        public int VehicleId { get; set; }

        public virtual HosStatus Status { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}