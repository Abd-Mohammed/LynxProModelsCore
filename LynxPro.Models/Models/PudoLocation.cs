
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class PudoLocation : TenantAware, ITenantAware
    {
        public PudoLocation()
        {
            PudoLocationKeywords = new HashSet<PudoLocationKeyword>();
            RestrictedPudoLocations = new HashSet<RestrictedPudoLocation>();
        }

        public int PudoLocationId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Pick up/Drop off Location Name")]
        public string Name { get; set; }

        [MaxLength(250)]
        [Display(Name = "Description", Description = "Pick up/Drop off Location Description")]
        public string Description { get; set; }

        [Range(-90d, 90d)]
        [Display(Name = "Latitude", Description = "Pick up/Drop off Location Latitude")]
        public double Latitude { get; set; }

        [Range(-180d, 180d)]
        [Display(Name = "Longitude", Description = "Pick up/Drop off Location Longitude")]
        public double Longitude { get; set; }

        [Range(25, 1000)]
        [Display(Name = "Radius", Description = "Pick up/Drop off Location Radius")]
        public double Radius { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Pick up/Drop off Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Pick up/Drop off Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Pick up/Drop off Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Pick up/Drop off Modified Date")]
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<PudoLocationKeyword> PudoLocationKeywords { get; set; }
        public virtual ICollection<RestrictedPudoLocation> RestrictedPudoLocations { get; set; }
    }
}