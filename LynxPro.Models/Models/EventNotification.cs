
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public enum EventNotificationType
    {
        [Display(Name = "Error")]
        Error = 1,
        [Display(Name = "Warning")]
        Warning = 2,
        [Display(Name = "Information")]
        Information = 3,
    }

    public class EventNotification : TenantAware, ITenantAware
    {
        public int EventNotificationId { get; set; }

        [Required]
        [Display(Name = "Description", Description = "Event Notification Description")]
        public string Description { get; set; }

        [Display(Name = "Details", Description = "Event Notification Details")]
        public string Details { get; set; }

        [Range(1, 3)]
        [Display(Name = "Type", Description = "Event Notification Type")]
        public EventNotificationType Type { get; set; }

        [Required]
        [MaxLength(25)]
        [Display(Name = "Source", Description = "Event Notification Source")]
        public string Source { get; set; }

        [MaxLength(100)]
        [Display(Name = "Url", Description = "Event Notification Url")]
        public string Url { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Event Notification Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Is Read", Description = "Is Event Notification Read")]
        public bool IsRead { get; set; }

        [Display(Name = "User", Description = "User Id")]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}