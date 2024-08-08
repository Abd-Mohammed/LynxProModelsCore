
using LynxPro.Models.Json;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class ProductType : TenantAware, ITenantAware
    {
        public int ProductTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Product Type Name")]
        public string Name { get; set; }

        [MaxLength(250)]
        [Display(Name = "Description", Description = "Product Type Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the attribute metadata, default value is []
        /// </summary>
        [Required]
        [Display(Name = "Attribute Document", Description = "Product Type Attribute Document")]
        public string AttributeDocument { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Product Type Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Product Type Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Product Type Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Product Type Modified Date")]
        public DateTime ModifiedDate { get; set; }

        [NotMapped]
        public IEnumerable<ProductTypeAttribute> Attributes { get { return JsonConvert.DeserializeObject<IEnumerable<ProductTypeAttribute>>(AttributeDocument); } }
    }
}