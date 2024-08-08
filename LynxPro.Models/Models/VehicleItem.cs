using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class VehicleItem : TenantAware, ITenantAware
    {
        [Display(Name = "Vehicle Group", Description = "Vehicle Group Id")]
        public int VehicleGroupId { get; set; }

        [Display(Name = "Vehicle", Description = "Vehicle Id")]
        public int VehicleId { get; set; }

        public virtual VehicleGroup VehicleGroup { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
