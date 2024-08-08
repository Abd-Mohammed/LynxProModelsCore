
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class PoiItem : TenantAware, ITenantAware
    {
        [Display(Name = "POI Group", Description = "POI Group Id")]
        public int PoiGroupId { get; set; }

        [Display(Name = "POI", Description = "POI Id")]
        public int PoiId { get; set; }

        public virtual PoiGroup PoiGroup { get; set; }
        public virtual Poi Poi { get; set; }
    }
}