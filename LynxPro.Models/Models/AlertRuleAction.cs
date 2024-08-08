
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class AlertRuleAction : TenantAware, ITenantAware
    {
        [Display(Name = "Alert Rule", Description = "Alert Rule Id")]
        public int AlertRuleId { get; set; }

        [Display(Name = "Action", Description = "Action Id")]
        public int ActionId { get; set; }

        public virtual AlertRule AlertRule { get; set; }
        public virtual Action Action { get; set; }
    }
}