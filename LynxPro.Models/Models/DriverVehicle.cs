
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class DriverVehicle : TenantAware, ITenantAware
    {
        [Display(Name = "Driver", Description = "Driver Id")]
        public int DriverId { get; set; }

        [Display(Name = "Vehicle", Description = "Vehicle Id")]
        public int VehicleId { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}