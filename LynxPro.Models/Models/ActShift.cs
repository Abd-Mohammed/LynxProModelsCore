
using LynxPro.Models.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class ActShift : TenantAware, ITenantAware, IFranchiseAware
    {
        public ActShift()
        {
            ActShiftBreaks = new HashSet<ActShiftBreak>();
        }

        public int ActShiftId { get; set; }

        public int FranchiseId { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Start Time", Description = "Shift Start Time")]
        public DateTime? StartTime { get; set; }

        [Display(Name = "Start Odometer", Description = "Shift Start Odometer")]
        public long? StartOdometer { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "End Time", Description = "Shift End Time")]
        public DateTime? EndTime { get; set; }

        [Display(Name = "End Odometer", Description = "Shift End Odometer")]
        public long? EndOdometer { get; set; }

        [Display(Name = "Work Length (sec)", Description = "Shift Work Length (sec)")]
        public int WorkLength { get; set; }

        [Display(Name = "Break Time Length (sec)", Description = "Shift Break Time Length (sec)")]
        public int BreakTimeLength { get; set; }

        [Display(Name = "Remaining Break Time Length (sec)", Description = "Shift Remaining Break Time Length (sec)")]
        public int RemainingBreakTimeLength { get; set; }

        [Display(Name = "Length (sec)", Description = "Shift Length (sec)")]
        public int Length { get; set; }

        [Display(Name = "Distance (m)", Description = "Shift Distance (m)")]
        public long Distance { get; set; }

        [Display(Name = "Driver", Description = "Driver Id")]
        public int DriverId { get; set; }

        [Display(Name = "Vehicle", Description = "Vehicle Id")]
        public int VehicleId { get; set; }

        [Display(Name = "Document", Description = "Document")]
        public string Document { get; set; }

        [NotMapped]
        public ShiftSummary Summary { get { return JsonMapper.MapOrDefault<ShiftSummary>(Document); } }

        public virtual Driver Driver { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual ICollection<ActShiftBreak> ActShiftBreaks { get; set; }
    }
}