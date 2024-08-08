using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class EmailNotificationRule : NotificationRule
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "Subject", Description = "Email Notification Rule Subject")]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "Body", Description = "Email Notification Rule Body")]
        public string Body { get; set; }

        [Display(Name = "Include Link", Description = "Email Notification Rule Include Link")]
        public bool IncludeLink { get; set; }

        [Range(1, 4)]
        [Display(Name = "Recipient", Description = "Email Notification Rule Recipient")]
        public NotificationRecipient Recipient { get; set; }

        [Display(Name = "Recipients", Description = "Email Notification Rule Recipients")]
        [RegularExpression(StandardEmailFormats.MultiWithSemicolon, ErrorMessage = "You must enter valid email addresses seperated by ';'")]
        public string Recipients { get; set; }

        [Display(Name = "Role", Description = "Role Id")]
        public int? RoleId { get; set; }

        [Range(1, 15)]
        [Display(Name = "Targeted Customers", Description = "Email Notification Targeted Customers")]
        public TargetedCustomers? TargetedCustomers { get; set; }

        public virtual Role Role { get; set; }
    }
}