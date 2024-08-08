
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class CityFareTransit : TenantAware, ITenantAware
    {
        public int CityFareTransitId { get; set; }

        [Range(0, 1000)]
        [Display(Name = "Fee", Description = "City Fare Transit Fee")]
        public decimal Fee { get; set; }

        [Display(Name = "City", Description = "City Id")]
        public int? CityId { get; set; }

        [Display(Name = "City Fare", Description = "City Fare Id")]
        public int CityFareId { get; set; }

        public virtual City City { get; set; }
        public virtual CityFare CityFare { get; set; }
    }
}