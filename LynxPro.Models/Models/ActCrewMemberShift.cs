using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class ActCrewMemberShift : TenantAware, ITenantAware
    {
        public int ActCrewMemberShiftId { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Start Time", Description = "Shift Start Time")]
        public DateTime? StartTime { get; set; }

        [Required]
        [Display(Name = "Address", Description = "Shift Address")]
        public string StartAddress { get; set; }

        [Display(Name = "Latitude", Description = "Shift Latitude")]
        public double StartLatitude { get; set; }

        [Display(Name = "Longitude", Description = "Shift Longitude")]
        public double StartLongitude { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Started By", Description = "Shift Started By")]
        public string StartedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "End Time", Description = "Shift End Time")]
        public DateTime? EndTime { get; set; }

        [Required]
        [Display(Name = "Address", Description = "Shift Address")]
        public string EndAddress { get; set; }

        [Display(Name = "Latitude", Description = "Shift Latitude")]
        public double EndLatitude { get; set; }

        [Display(Name = "Longitude", Description = "Shift Longitude")]
        public double EndLongitude { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Ended By", Description = "Shift Ended By")]
        public string EndedBy { get; set; }

        [Display(Name = "Work Length (sec)", Description = "Shift Work Length (sec)")]
        public int WorkLength { get; set; }

        [Display(Name = "Break Time Length (sec)", Description = "Shift Break Time Length (sec)")]
        public int BreakTimeLength { get; set; }

        [Display(Name = "Remaining Break Time Length (sec)", Description = "Shift Remaining Break Time Length (sec)")]
        public int RemainingBreakTimeLength { get; set; }

        [Display(Name = "Length (sec)", Description = "Shift Length (sec)")]
        public int Length { get; set; }

        [Display(Name = "Crew Member", Description = "Crew Member Id")]
        public int CrewMemberId { get; set; }

        [Display(Name = "Vehicle", Description = "Vehicle Id")]
        public int VehicleId { get; set; }

        public virtual CrewMember CrewMember { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
