
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class DriverVehicleType : TenantAware, ITenantAware
    {
        [Display(Name = "Driver", Description = "Driver Id")]
        public int DriverId { get; set; }

        [Display(Name = "Vehicle Type", Description = "Vehicle Type Id")]
        public int VehicleTypeId { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual VehicleType VehicleType { get; set; }
    }
}