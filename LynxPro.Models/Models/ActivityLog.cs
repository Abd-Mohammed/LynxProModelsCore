
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public enum ActivityLogType
    {
        [Display(Name = "Add")]
        Add = 1,
        [Display(Name = "Change")]
        Change = 2,
        [Display(Name = "Remove")]
        Remove = 3
    }

    public class ActivityLog : TenantAware, ITenantAware
    {
        public int ActivityLogId { get; set; }

        [Range(1, 3)]
        [Display(Name = "Type", Description = "Activity Log Type")]
        public ActivityLogType Type { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Entity Name", Description = "Activity Log Entity Name")]
        public string EntityName { get; set; }

        [Display(Name = "Entity Key", Description = "Activity Log Entity Key")]
        public int EntityKey { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Title", Description = "Activity Log Title")]
        public string Title { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Time", Description = "Activity Log Time")]
        public DateTime Time { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Username", Description = "Activity Log Username")]
        public string Username { get; set; }

        [Display(Name = "Details", Description = "Activity Log Details")]
        public string Details { get; set; }
    }
}