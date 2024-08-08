
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class ProductInventory : TenantAware, ITenantAware
    {
        [Display(Name = "Warehouse", Description = "Warehouse Id")]
        public int WarehouseId { get; set; }

        [Display(Name = "Product", Description = "Product Id")]
        public int ProductId { get; set; }

        [Range(0, 1000000)]
        [Display(Name = "Quantity", Description = "Product Inventory Quantity")]
        public int Quantity { get; set; }

        public virtual Warehouse Warehouse { get; set; }

        public virtual Product Product { get; set; }
    }
}