using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class TrackedItemType : TenantAware, ITenantAware
    {
        public int TrackedItemTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Tracked Asset Type Name")]
        public string Name { get; set; }

        [MaxLength(250)]
        [Display(Name = "Description", Description = "Tracked Asset Type Description")]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Tracked Asset Type Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Tracked Asset Type Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Tracked Asset Type Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Tracked Asset Type Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}