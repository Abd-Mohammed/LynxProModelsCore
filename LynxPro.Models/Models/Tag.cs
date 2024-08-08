
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class Tag : TenantAware, ITenantAware
    {
        public int TagId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Tag Name")]
        public string Name { get; set; }
    }
}