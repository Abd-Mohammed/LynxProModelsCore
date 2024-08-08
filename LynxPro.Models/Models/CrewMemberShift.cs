
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class CrewMemberShift : TenantAware, ITenantAware
    {
        [Display(Name = "Crew Member", Description = "Crew Member Id")]
        public int CrewMemberId { get; set; }

        [Display(Name = "Shift", Description = "Shift Id")]
        public int ShiftId { get; set; }

        public virtual CrewMember CrewMember { get; set; }
        public virtual Shift Shift { get; set; }
    }
}