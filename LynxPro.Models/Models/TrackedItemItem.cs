using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class TrackedItemItem : TenantAware, ITenantAware
    {
        [Display(Name = "Tracked Asset Group", Description = "Tracked Asset Group Id")]
        public int TrackedItemGroupId { get; set; }

        [Display(Name = "Tracked Asset", Description = "Tracked Asset Id")]
        public int TrackedItemId { get; set; }

        public virtual TrackedItemGroup TrackedItemGroup { get; set; }
        public virtual TrackedItem TrackedItem { get; set; }
    }
}
