
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public enum EscalationChainEntityType
    {
        Vehicle = 1,
        TrackedItem = 2,
    }

    public class EscalationChain : TenantAware, ITenantAware
    {
        public EscalationChain()
        {
            EscalationRules = new HashSet<EscalationRule>();
        }

        public int EscalationChainId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Escalation Chain Name")]
        public string Name { get; set; }

        [Display(Name = "Entity Type", Description = "Escalation Chain Entity Type")]
        public EscalationChainEntityType EntityType { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Escalation Chain Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Escalation Chain Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Escalation Chain Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Escalation Chain Modified Date")]
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<EscalationRule> EscalationRules { get; set; }
    }
}