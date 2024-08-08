
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class ActShiftBreak : TenantAware, ITenantAware
    {
        public int ActShiftBreakId { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Start Time", Description = "Break Start Time")]
        public DateTime? StartTime { get; set; }

        [Display(Name = "Length", Description = "Break Length (sec)")]
        public int Length { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "End Time", Description = "Break End Time")]
        public DateTime? EndTime { get; set; }

        [Display(Name = "Act Shift", Description = "Act Shift Id")]
        public int ActShiftId { get; set; }

        public virtual ActShift ActShift { get; set; }
    }
}