using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class PushNotificationRule : NotificationRule
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Body", Description = "Push Notification Rule Body")]
        public string Body { get; set; }

        [Display(Name = "Role", Description = "Role Id")]
        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
