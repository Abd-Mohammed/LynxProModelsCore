
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class RideTypeVehicleType : TenantAware, ITenantAware
    {
        [Display(Name = "Ride Type", Description = "Ride Type Id")]
        public int RideTypeId { get; set; }

        [Display(Name = "Vehicle Type", Description = "Vehicle Type Id")]
        public int VehicleTypeId { get; set; }

        public virtual RideType RideType { get; set; }
        public virtual VehicleType VehicleType { get; set; }
    }
}