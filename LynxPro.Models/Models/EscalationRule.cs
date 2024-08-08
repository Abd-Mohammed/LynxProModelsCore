
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public enum EscalationRuleEvent
    {
        [Display(Name = "Incident Count")]
        IncidentCount = 1,
        [Display(Name = "Duration")]
        Duration = 2,
        [Display(Name = "Resolution State Change")]
        ResolutionStateChange = 3,
        [Display(Name = "Period")]
        Period = 4,
        [Display(Name = "Succeeded Action")]
        SucceededAction = 5,
        [Display(Name = "Failed Action")]
        FailedAction = 6,
    }

    public class EscalationRule : TenantAware, ITenantAware
    {
        public EscalationRule()
        {
            EscalationRuleNotificationRules = new HashSet<EscalationRuleNotificationRule>();
            EscalationRuleActions = new HashSet<EscalationRuleAction>();
        }

        public int EscalationRuleId { get; set; }

        [Range(1, 100)]
        [Display(Name = "Level", Description = "Escalation Rule Level")]
        public int Level { get; set; }

        [Range(1, 6)]
        [Display(Name = "Event", Description = "Escalation Rule Event")]
        public EscalationRuleEvent Event { get; set; }

        [Range(1, 1000)]
        [Display(Name = "Incident Count", Description = "Escalation Rule Incident Count")]
        public int? IncidentCount { get; set; }

        [Range(1, 120)]
        [Display(Name = "Duration (min)", Description = "Escalation Rule Duration (min)")]
        public int? Duration { get; set; }

        [Range(1, 120)]
        [Display(Name = "Period (min)", Description = "Escalation Rule Period (min)")]
        public int? Period { get; set; }

        [Range(1, 10)]
        [Display(Name = "Action Count", Description = "Escalation Rule Action Count")]
        public int? ActionCount { get; set; }

        [Display(Name = "Resolution State", Description = "Resolution State Id")]
        public int? ResolutionStateId { get; set; }

        [Display(Name = "Escalation Chain", Description = "Escalation Chain Id")]
        public int EscalationChainId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Escalation Rule Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Escalation Rule Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Escalation Rule Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Escalation Rule Modified Date")]
        public DateTime ModifiedDate { get; set; }

        public virtual EscalationChain EscalationChain { get; set; }
        public virtual ResolutionState ResolutionState { get; set; }
        public virtual ICollection<EscalationRuleNotificationRule> EscalationRuleNotificationRules { get; set; }
        public virtual ICollection<EscalationRuleAction> EscalationRuleActions { get; set; }
    }
}