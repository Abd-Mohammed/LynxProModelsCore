
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class AlertRuleNotificationRule : TenantAware, ITenantAware
    {
        [Display(Name = "Alert Rule", Description = "Alert Rule Id")]
        public int AlertRuleId { get; set; }

        [Display(Name = "Notification Rule", Description = "Notification Rule Id")]
        public int NotificationRuleId { get; set; }

        public virtual AlertRule AlertRule { get; set; }
        public virtual NotificationRule NotificationRule { get; set; }
    }
}