using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class EventNotificationRule : NotificationRule
    {
        [Required(ErrorMessage = "")]
        [MaxLength(100, ErrorMessage = "")]
        [Display(Name = "Text", Description = "Notification Rule Text")]
        public string Text { get; set; }

        [Display(Name = "Role", Description = "Role Id")]
        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}