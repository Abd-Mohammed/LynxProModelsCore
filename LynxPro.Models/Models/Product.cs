
using LynxPro.Models.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class Product : TenantAware, ITenantAware
    {
        public int ProductId { get; set; }

        [Required]
        [MaxLength(10)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Number", Description = "Product Number")]
        public string Number { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Product Name")]
        public string Name { get; set; }

        [MaxLength(250)]
        [Display(Name = "Description", Description = "Product Description")]
        public string Description { get; set; }

        [Range(0, 10000)]
        [Display(Name = "Price Amount", Description = "Product Price Amount")]
        public decimal PriceAmount { get; set; }

        [Required]
        [MaxLength(3)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Currency Code", Description = "Product Price Currency Code")]
        public string PriceCurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the info metadata
        /// </summary>
        [Required]
        [Display(Name = "Info Document", Description = "Product Info Document")]
        public string InfoDocument { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Product Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Product Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Product Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Product Modified Date")]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "Product Type", Description = "Product Type Id")]
        public int ProductTypeId { get; set; }

        [NotMapped]
        public ProductInfo Info { get { return JsonMapper.Map<ProductInfo>(InfoDocument); } }

        public virtual ProductType ProductType { get; set; }
    }
}