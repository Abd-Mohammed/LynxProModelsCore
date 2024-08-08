using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class VehicleCrewMember : TenantAware, ITenantAware
    {
        [Display(Name = "Vehicle", Description = "Vehicle Id")]
        public int VehicleId { get; set; }

        [Display(Name = "Crew Member", Description = "Crew Member Id")]
        public int CrewMemberId { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual CrewMember CrewMember { get; set; }
    }
}