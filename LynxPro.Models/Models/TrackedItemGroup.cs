using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class TrackedItemGroup : TenantAware, ITenantAware
    {
        public int TrackedItemGroupId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Tracked Asset Group Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Tracked Asset Group Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Tracked Asset Group Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Tracked Asset Group Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Tracked Asset Group Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}