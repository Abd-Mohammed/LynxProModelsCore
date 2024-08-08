
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class DriverShift : TenantAware, ITenantAware
    {
        [Display(Name = "Driver", Description = "Driver Id")]
        public int DriverId { get; set; }

        [Display(Name = "Shift", Description = "Shift Id")]
        public int ShiftId { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual Shift Shift { get; set; }
    }
}