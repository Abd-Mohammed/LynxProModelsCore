
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class Rule : TenantAware, ITenantAware
    {
        public int RuleId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Rule Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Template", Description = "Rule Template")]
        public string Template { get; set; }

        [Required]
        [Display(Name = "Type", Description = "Rule Type")]
        public string Type { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Rule Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Rule Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Rule Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Rule Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}