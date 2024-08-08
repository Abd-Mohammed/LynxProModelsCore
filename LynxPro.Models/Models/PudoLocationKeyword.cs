
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class PudoLocationKeyword : TenantAware, ITenantAware
    {
        public int PudoLocationKeywordId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Name", Description = "Pudo Location Keyword Name")]
        public string Name { get; set; }

        [Display(Name = "Pick up/Drop off Location", Description = "Pick up/Drop off Location Id")]
        public int PudoLocationId { get; set; }

        public virtual PudoLocation PudoLocation { get; set; }
    }
}