using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class VcrCategory : TenantAware, ITenantAware
    {
        public int VcrCategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "VCR Category Name")]
        public string Name { get; set; }

        [MaxLength(250)]
        [Display(Name = "Description", Description = "VCR Category Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Image Blob Name", Description = "VCR Category Image Blob Name")]
        public string ImageBlobName { get; set; }

        [Display(Name = "Is Critical", Description = "Is VCR Category Critical")]
        public bool IsCritical { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "VCR Category Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "VCR Category Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "VCR Category Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "VCR Category Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}