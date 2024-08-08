
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class FineType : TenantAware, ITenantAware
    {
        public int FineTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Fine Type Name")]
        public string Name { get; set; }

        [MaxLength(250)]
        [Display(Name = "Description", Description = "Fine Type Description")]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Fine Type Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Fine Type Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Fine Type Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Fine Type Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}
