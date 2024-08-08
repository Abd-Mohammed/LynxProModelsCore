
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class ResolutionState : TenantAware, ITenantAware
    {
        public int ResolutionStateId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Description", Description = "Resolution State Description")]
        public string Description { get; set; }

        [Range(1, 255)]
        [Display(Name = "Number", Description = "Resolution State Number")]
        public int Number { get; set; }

        [Display(Name = "Is Default", Description = "Is Resolution State Default")]
        public bool IsDefault { get; set; }
    }
}