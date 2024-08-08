
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class MaintenanceService : TenantAware, ITenantAware
    {
        public MaintenanceService()
        {
            MaintenanceServiceParts = new HashSet<MaintenanceServicePart>();
        }

        public int MaintenanceServiceId { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Date", Description = "Maintenance Service Date")]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Provider", Description = "Maintenance Service Provider")]
        public string Provider { get; set; }

        [Display(Name = "Odometer", Description = "Maintenance Service Odometer")]
        public long Odometer { get; set; }

        [Display(Name = "Engine Hours", Description = "Maintenance Service Engine Hours")]
        public double EngineHours { get; set; }

        [MaxLength(500)]
        [Display(Name = "Initial Inspection", Description = "Maintenance Service Initial Inspection")]
        public string InitialInspection { get; set; }

        [MaxLength(500)]
        [Display(Name = "Final Inspection", Description = "Maintenance Service Final Inspection")]
        public string FinalInspection { get; set; }

        [MaxLength(250)]
        [Display(Name = "Notes", Description = "Maintenance Service Notes")]
        public string Notes { get; set; }

        [MaxLength(50)]
        [Display(Name = "Invoice Reference No", Description = "Maintenance Service Invoice Reference No")]
        public string InvoiceReferenceNo { get; set; }

        [Display(Name = "Cost", Description = "Maintenance Service Cost")]
        public double Cost { get; set; }

        [Display(Name = "Maintenance Service Type", Description = "Maintenance Service Type Id")]
        public int MaintenanceServiceTypeId { get; set; }

        [Display(Name = "Vehicle", Description = "Vehicle Id")]
        public int VehicleId { get; set; }

        [Display(Name = "Driver", Description = "Driver Id")]
        public int? DriverId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Maintenance Service Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Maintenance Service Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Maintenance Service Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Maintenance Service Modified Date")]
        public DateTime ModifiedDate { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual MaintenanceServiceType MaintenanceServiceType { get; set; }
        public virtual ICollection<MaintenanceServicePart> MaintenanceServiceParts { get; set; }
    }
}