
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class CityFareExtraCharge : TenantAware, ITenantAware
    {
        public int CityFareExtraChargeId { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Name", Description = "Fare Extra Charge Name")]
        public string Name { get; set; }

        [Range(0, 1000)]
        [Display(Name = "Fee", Description = "Fare Extra Charge Fee")]
        public decimal Fee { get; set; }

        [Display(Name = "City Fare", Description = "City Fare Id")]
        public int CityFareId { get; set; }

        public virtual CityFare CityFare { get; set; }
    }
}