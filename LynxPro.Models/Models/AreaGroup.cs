
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class AreaGroup : TenantAware, ITenantAware
    {
        public int AreaGroupId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Area Group Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Area Group Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Area Group Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Area Group Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Area Group Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}