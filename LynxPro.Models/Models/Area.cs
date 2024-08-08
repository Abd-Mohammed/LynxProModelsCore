using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public enum OverlayType
    {
        [Display(Name = "Circle")]
        Circle = 1,
        [Display(Name = "Polygon")]
        Polygon = 2,
        [Display(Name = "Rectangle")]
        Rectangle = 3
    }

    public class Area : TenantAware, ITenantAware
    {
        public int AreaId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Area Name")]
        public string Name { get; set; }

        [MaxLength(250)]
        [Display(Name = "Description", Description = "Area Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Geom Object", Description = "Area Geom Object")]
        public Geometry GeomObject { get; set; }

        [Required]
        [Display(Name = "Overlay", Description = "Area Overlay")]
        public string Overlay { get; set; }

        [Display(Name = "Overlay Type", Description = "Area Overlay Type")]
        [Range(1, 3, ErrorMessage = "The {0} field is required.")]
        public OverlayType OverlayType { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Area Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Area Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Area Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Area Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}