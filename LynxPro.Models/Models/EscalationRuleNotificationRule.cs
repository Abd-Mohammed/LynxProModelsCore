
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class EscalationRuleNotificationRule : TenantAware, ITenantAware
    {
        [Display(Name = " Escalation Rule", Description = "Escalation Rule Id")]
        public int EscalationRuleId { get; set; }

        [Display(Name = "Notification Rule", Description = "Notification Rule Id")]
        public int NotificationRuleId { get; set; }

        public virtual EscalationRule EscalationRule { get; set; }
        public virtual NotificationRule NotificationRule { get; set; }
    }
}