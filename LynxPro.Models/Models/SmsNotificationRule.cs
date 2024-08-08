using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class SmsNotificationRule : NotificationRule
    {
        [Required]
        [MaxLength(150)]
        [Display(Name = "Message", Description = "SMS Notification Rule Message")]
        public string Message { get; set; }

        [Range(1, 4)]
        [Display(Name = "Recipient", Description = "SMS Notification Rule Recipient")]
        public NotificationRecipient Recipient { get; set; }

        [Display(Name = "Recipients", Description = "SMS Notification Rule Recipients")]
        [RegularExpression(StandardPhoneNoFormats.MultiWithSemicolon, ErrorMessage = "[[[[You must enter valid numbers seperated by ';']]]]")]
        public string Recipients { get; set; }

        [Display(Name = "Role", Description = "Role Id")]
        public int? RoleId { get; set; }

        [Range(1, 15)]
        [Display(Name = "Targeted Customers", Description = "SMS Notification Targeted Customers")]
        public TargetedCustomers? TargetedCustomers { get; set; }

        public virtual Role Role { get; set; }
    }
}