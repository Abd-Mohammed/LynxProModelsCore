
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    [Flags]
    public enum ActionCategories
    {
        [Display(Name = "Tracked Asset")]
        TrackedItem = 1,
        [Display(Name = "Vehicle")]
        Vehicle = 2,
    }

    public enum ActionType
    {
        [Display(Name = "Command")]
        Command = 1,
        [Display(Name = "Event")]
        Event = 2,
        [Display(Name = "Fine")]
        Fine = 3,
        [Display(Name = "Rest")]
        Rest = 4,
        [Display(Name = "Database")]
        Database = 5,
        [Display(Name = "Other")]
        Other = 6,
    }

    public class Action : TenantAware, ITenantAware
    {
        public int ActionId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Action Name")]
        public string Name { get; set; }

        [MaxLength(250)]
        [Display(Name = "Description", Description = "Action Description")]
        public string Description { get; set; }

        [Range(1, 6)]
        [Display(Name = "Type", Description = "Action Type")]
        public ActionType Type { get; set; }

        [Range(1, 2)]
        [Display(Name = "Category", Description = "Action Category")]
        public ActionCategories Category { get; set; }

        [Required]
        [Display(Name = "Template", Description = "Action Template")]
        public string Template { get; set; }

        [Display(Name = "Manual Workflow", Description = "Action Manual Workflow")]
        public bool ManualWorkflow { get; set; }

        [Display(Name = "Is Locked", Description = "Is Action Locked")]
        public bool IsLocked { get; set; }

        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Action Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Action Created Date")]
        public DateTime CreatedDate { get; set; }

        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Action Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Action Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}