
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class AlertComment : ITenantAware
    {
        public int AlertCommentId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Text", Description = "Predefined Comment Text")]
        public string Text { get; set; }

        public int TenantId { get; set; }
    }
}