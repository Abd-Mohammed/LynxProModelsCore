
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class MaintenanceServicePart : TenantAware, ITenantAware
    {
        public int MaintenanceServicePartId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Maintenance Service Part Name")]
        public string Name { get; set; }

        [Range(1, 100)]
        [Display(Name = "Quantity", Description = "Maintenance Service Part Quantity")]
        public int Quantity { get; set; }

        [Range(1, 10000)]
        [Display(Name = "Cost", Description = "Maintenance Service Part Cost")]
        public double Cost { get; set; }

        [Display(Name = "Maintenance Service", Description = "Maintenance Service Id")]
        public int MaintenanceServiceId { get; set; }

        public virtual MaintenanceService MaintenanceService { get; set; }
    }
}