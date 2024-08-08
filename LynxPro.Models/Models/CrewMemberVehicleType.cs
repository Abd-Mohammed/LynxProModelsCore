
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class CrewMemberVehicleType : TenantAware, ITenantAware
    {
        [Display(Name = "Crew Member", Description = "Crew Member Id")]
        public int CrewMemberId { get; set; }

        [Display(Name = "Vehicle Type", Description = "Vehicle Type Id")]
        public int VehicleTypeId { get; set; }

        public virtual CrewMember CrewMember { get; set; }
        public virtual VehicleType VehicleType { get; set; }
    }
}