
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class AlertRuleTag : TenantAware, ITenantAware
    {
        [Display(Name = "Alert Rule", Description = "Alert Rule Id")]
        public int AlertRuleId { get; set; }

        [Display(Name = "Alert Rule Tag", Description = "Alert Rule Tag Id")]
        public int TagId { get; set; }

        public virtual AlertRule AlertRule { get; set; }
        public virtual Tag Tag { get; set; }
    }
}