
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class OrderLine : TenantAware, ITenantAware
    {
        public long OrderLineId { get; set; }

        [Range(0, 1000)]
        [Display(Name = "Quantity", Description = "Order Line Quantity")]
        public int Quantity { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Description", Description = "Order Line Description")]
        public string Description { get; set; }

        [Required]
        [MaxLength(10)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Product Number", Description = "Order Line Product Number")]
        public string ProductNumber { get; set; }

        [Range(0, 10000)]
        [Display(Name = "Price Amount", Description = "Order Line Price Amount")]
        public decimal PriceAmount { get; set; }

        [Required]
        [MaxLength(3)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Currency Code", Description = "Order Line Price Currency Code")]
        public string PriceCurrencyCode { get; set; }

        [Range(0, 10000)]
        [Display(Name = "Tax Amount", Description = "Order Line Tax Amount")]
        public decimal TaxAmount { get; set; }

        [Required]
        [MaxLength(3)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Tax Currency Code", Description = "Order Line Tax Currency Code")]
        public string TaxCurrencyCode { get; set; }

        [Range(0, 100000)]
        [Display(Name = "Total Amount", Description = "Order Line Total Amount")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Order", Description = "Order Id")]
        public long OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}