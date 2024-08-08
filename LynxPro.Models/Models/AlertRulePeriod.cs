
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{

    public class AlertRulePeriod : TenantAware, ITenantAware
    {
        public int AlertRulePeriodId { get; set; }

        [Display(Name = "Recurring Day", Description = "Alert Rule Period Day")]
        public RecurringDay? RecurringDay { get; set; }

        [Display(Name = "Days of Week", Description = "Alert Rule Period Days of Week")]
        public DaysOfWeek? DaysOfWeek { get; set; }

        [Display(Name = "Recurring Time", Description = "Alert Rule Period Recurring Time")]
        public RecurringTime? RecurringTime { get; set; }

        [Display(Name = "From Time", Description = "Alert Rule Period From Time")]
        public TimeSpan? FromTime { get; set; }

        [Display(Name = "To Time", Description = "Alert Rule Period To Time")]
        public TimeSpan? ToTime { get; set; }

        [Display(Name = "Alert Rule", Description = "Alert Rule Id")]
        public int AlertRuleId { get; set; }

        public virtual AlertRule AlertRule { get; set; }
    }
}
