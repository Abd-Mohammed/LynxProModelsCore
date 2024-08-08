
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class ProductSpecification : TenantAware, ITenantAware
    {
        public int ProductSpecificationId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Product Specification Name")]
        public string Name { get; set; }

        [MaxLength(250)]
        [Display(Name = "Description", Description = "Product Specification Description")]
        public string Description { get; set; }

        [MaxLength(25)]
        [Display(Name = "Icon Name", Description = "Product Specification Icon Name")]
        public string IconName { get; set; }

        [MaxLength(7)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Color", Description = "Product Specification Icon Color")]
        public string IconColor { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Product Specification Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Product Specification Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Product Specification Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Product Specification Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}