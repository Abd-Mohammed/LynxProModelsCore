using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class Poi : TenantAware, ITenantAware
    {
        public Poi()
        {
            PoiRemarks = new HashSet<PoiRemark>();
        }

        public int PoiId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "POI Name")]
        public string Name { get; set; }

        [MaxLength(250)]
        [Display(Name = "Description", Description = "POI Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Geom Object", Description = "POI Geom Object")]
        public Geometry GeomObject { get; set; }

        [Required]
        [Display(Name = "Overlay", Description = "POI Overlay")]
        public string Overlay { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "POI Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "POI Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "POI Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "POI Modified Date")]
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<PoiRemark> PoiRemarks { get; set; }
    }
}