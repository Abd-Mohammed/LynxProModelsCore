using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class City : TenantAware, ITenantAware, IIntegrationAware
    {
        public int CityId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "City Name")]
        public string Name { get; set; }

        [MaxLength(250)]
        [Display(Name = "Description", Description = "City Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "City", Description = "City Overlay")]
        public string Overlay { get; set; }

        [Required]
        [Display(Name = "Location", Description = "City Location")]
        public Geometry Location { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "City Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "City Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "City Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "City Modified Date")]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "Parent", Description = "Parent Id")]
        public int? ParentId { get; set; }

        [Display(Name = "Integration Id", Description = "City Integration Id")]
        public int? IntegrationId { get; set; }

        public virtual City Parent { get; set; }

        [NotMapped]
        public IEnumerable<City> Cities { get; set; }
    }
}