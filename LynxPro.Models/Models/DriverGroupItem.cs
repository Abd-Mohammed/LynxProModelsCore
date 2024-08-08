
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class DriverGroupItem : TenantAware, ITenantAware
    {
        [Display(Name = "Driver Group", Description = "Driver Group Id")]
        public int DriverGroupId { get; set; }

        [Display(Name = "Driver", Description = "Driver Id")]
        public int DriverId { get; set; }

        public virtual DriverGroup DriverGroup { get; set; }
        public virtual Driver Driver { get; set; }
    }
}