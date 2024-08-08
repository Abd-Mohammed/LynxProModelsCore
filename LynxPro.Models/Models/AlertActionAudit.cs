
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public enum AlertActionAuditStatus
    {
        [Display(Name = "Success")]
        Success = 1,
        [Display(Name = "Error")]
        Error = 2,
    }

    public class AlertActionAudit : TenantAware, ITenantAware
    {
        public int AlertActionAuditId { get; set; }

        [Required]
        [Display(Name = "Name", Description = "Alert Action Audit Name")]
        public string Name { get; set; }

        [Range(1, 4)]
        [Display(Name = "Type", Description = "Alert Action Audit Type")]
        public ActionType Type { get; set; }

        [MaxLength(50)]
        [Display(Name = "Vehicle Name", Description = "Alert Action Audit Vehicle Name")]
        public string VehicleName { get; set; }

        [MaxLength(25)]
        [Display(Name = "Vehicle Plate No", Description = "Alert Action Audit Vehicle Plate No")]
        public string VehiclePlateNo { get; set; }

        [MaxLength(50)]
        [Display(Name = "Tracked Asset Name", Description = "Alert Action Audit Tracked Asset Name")]
        public string TrackedItemName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Triggered By", Description = "Enforced Triggered By")]
        public string TriggeredBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Triggered Date", Description = "Alert Action Audit Triggered Date")]
        public DateTime TriggeredDate { get; set; }

        [Range(1, 4)]
        [Display(Name = "Status", Description = "Alert Action Audit Status")]
        public AlertActionAuditStatus Status { get; set; }

        [Display(Name = "Error Message", Description = "Alert Action Audit Error Message")]
        public string ErrorMessage { get; set; }
    }
}