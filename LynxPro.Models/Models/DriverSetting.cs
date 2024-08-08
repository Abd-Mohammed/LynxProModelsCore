
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class DriverSetting : TenantAware, ITenantAware
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "Time Zone", Description = "User Time Zone Id")]
        public string TimeZoneId { get; set; }

        [Required]
        [MaxLength(3)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Display Language", Description = "User Setting Display Language")]
        public string DisplayLanguage { get; set; }

        public int DriverId { get; set; }

        public virtual Driver Driver { get; set; }
    }
}