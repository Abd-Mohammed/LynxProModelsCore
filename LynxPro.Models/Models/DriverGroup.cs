
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class DriverGroup : TenantAware, ITenantAware
    {
        public int DriverGroupId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Driver Group Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Driver Group Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Driver Group Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Driver Group Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Driver Group Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}
