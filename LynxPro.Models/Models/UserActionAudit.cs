using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public enum AuditSection
    {
        [Display(Name = "Account")]
        Account = 1,
        [Display(Name = "Alerts")]
        Alerts = 2,
        [Display(Name = "Media")]
        Media = 3,
        [Display(Name = "Dispatch")]
        Dispatch = 4,
        [Display(Name = "Vehicle Management")]
        VehicleManagement = 5,
        [Display(Name = "Track asset Management")]
        TrackAssetManagement = 6,
        [Display(Name = "Vehicle Inspection")]
        VehicleInspection = 7,
        [Display(Name = "[[[[Video Download]]]]")]
        VideoDownload = 8
    }

    public class UserActionAudit : TenantAware, ITenantAware
    {
        public int UserActionAuditId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Username", Description = "User Action Audit Username")]
        public string Username { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Email", Description = "User Action Audit Email")]
        [RegularExpression(StandardEmailFormats.Default, ErrorMessage = "You must enter a valid email address")]
        public string Email { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "Action", Description = "User Action Audit Action")]
        public string Action { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Time", Description = "User Action Audit Time")]
        public DateTime Time { get; set; }

        [Range(1, 5)]
        [Display(Name = "Section", Description = "User Action Audit Section")]
        public AuditSection Section { get; set; }

        [Display(Name = "Details", Description = "User Action Audit Details")]
        public string Details { get; set; }
    }
}