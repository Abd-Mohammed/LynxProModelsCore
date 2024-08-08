
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public enum DayOfWeek
    {
        [Display(Name = "Monday")]
        Monday = 1,
        [Display(Name = "Tuesday")]
        Tuesday = 2,
        [Display(Name = "Wednesday")]
        Wednesday = 3,
        [Display(Name = "Thursday")]
        Thursday = 4,
        [Display(Name = "Friday")]
        Friday = 5,
        [Display(Name = "Saturday")]
        Saturday = 6,
        [Display(Name = "Sunday")]
        Sunday = 7
    }

    public class FareSchedulePeriod : TenantAware, ITenantAware
    {
        public int FareSchedulePeriodId { get; set; }

        [Range(1, 7)]
        [Display(Name = "Day of Week", Description = "Fare Schedule Period Day of Week")]
        public DayOfWeek DayOfWeek { get; set; }

        [Display(Name = "From Time", Description = "Fare Schedule Period From Time")]
        public TimeSpan FromTime { get; set; }

        [Display(Name = "To Time", Description = "Fare Schedule Period To Time")]
        public TimeSpan ToTime { get; set; }

        [Display(Name = "Fare Schedule", Description = "Fare Schedule Id")]
        public int FareScheduleId { get; set; }

        public virtual FareSchedule FareSchedule { get; set; }
    }
}