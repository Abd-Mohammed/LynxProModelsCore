
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class SlaAlertRule : TenantAware, ITenantAware
    {
        public int SlaAlertRuleId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "SLA Alert Rule Name")]
        public string Name { get; set; }

        [MaxLength(250)]
        [Display(Name = "Description", Description = "SLA Alert Rule Description")]
        public string Description { get; set; }

        [Range(1, 11520)]
        [Display(Name = "Allowed Time (min)", Description = "SLA Alert Rule Allowed Time (min)")]
        public int AllowedTime { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Alert Rule Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Alert Rule Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Alert Rule Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Alert Rule Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}
