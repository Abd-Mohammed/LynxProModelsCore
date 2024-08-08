

namespace LynxPro.Models
{
    public class RestrictedPudoLocation : TenantAware, ITenantAware
    {
        public int VehicleTypeId { get; set; }

        public int PudoLocationId { get; set; }

        public virtual VehicleType VehicleType { get; set; }

        public virtual PudoLocation PudoLocation { get; set; }
    }
}
