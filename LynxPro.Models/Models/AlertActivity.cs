
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public enum AlertActivityType
    {
        [Display(Name = "State Change")]
        StateChange = 1,
        [Display(Name = "Escalation")]
        Escalation = 2,
        [Display(Name = "Notification")]
        Notification = 3,
        [Display(Name = "Action")]
        Action = 4,
        [Display(Name = "Action Monitoring")]
        ActionMonitoring = 5,
    }

    public class AlertActivity : TenantAware, ITenantAware, IFranchiseAware
    {
        public int AlertActivityId { get; set; }

        public int FranchiseId { get; set; }

        [Range(1, 5)]
        [Display(Name = "Type", Description = "Alert Activity Type")]
        public AlertActivityType Type { get; set; }

        [Required]
        [Display(Name = "Description", Description = "Alert Activity Description")]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Time", Description = "Alert Activity Time")]
        public DateTime Time { get; set; }

        [MaxLength(50)]
        [Display(Name = "Username", Description = "Alert Activity Username")]
        public string Username { get; set; }

        [Display(Name = "Details", Description = "Alert Activity Details")]
        public string Details { get; set; }

        [Display(Name = "Alert", Description = "Alert Id")]
        public int AlertId { get; set; }

        public virtual Alert Alert { get; set; }
    }
}