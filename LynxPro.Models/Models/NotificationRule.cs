
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public enum NotificationRecipient
    {
        [Display(Name = "Driver")]
        Driver = 1,
        [Display(Name = "Customer")]
        Customer = 2,
        [Display(Name = "User")]
        User = 3,
        [Display(Name = "Custom")]
        Custom = 4,
    }

    public enum NotificationObject
    {
        [Display(Name = "Vehicle")]
        Vehicle = 1,
        [Display(Name = "Tracked Asset")]
        TrackedItem = 2,
    }

    [Flags]
    public enum TargetedCustomers
    {
        [Display(Name = "Incomplete")]
        Incomplete = 1,
        [Display(Name = "Previously Completed")]
        PreviouslyCompleted = 2,
        [Display(Name = "Currently Being Completed")]
        CurrentlyBeingCompleted = 4,
        [Display(Name = "Next To Complete")]
        NextToComplete = 8,
    }

    public abstract class NotificationRule : TenantAware, ITenantAware
    {
        public int NotificationRuleId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Notification Rule Name")]
        public string Name { get; set; }

        [Range(1, 2)]
        [Display(Name = "Object", Description = "Notification Rule Object")]
        public NotificationObject Object { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Notification Rule Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Notification Rule Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Notification Rule Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Notification Rule Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}