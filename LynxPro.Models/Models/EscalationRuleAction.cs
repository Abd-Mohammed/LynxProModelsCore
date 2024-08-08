
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class EscalationRuleAction : TenantAware, ITenantAware
    {
        [Display(Name = " Escalation Rule", Description = "Escalation Rule Id")]
        public int EscalationRuleId { get; set; }

        [Display(Name = "Action", Description = "Action Id")]
        public int ActionId { get; set; }

        public virtual EscalationRule EscalationRule { get; set; }
        public virtual Action Action { get; set; }
    }
}