
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class AuditVehicle : TenantAware, ITenantAware
    {
        public int AuditVehicleId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Vehicle Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(25)]
        [Display(Name = "Plate No", Description = "Vehicle Plate No")]
        public string PlateNo { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Action", Description = "Audit Vehicle Action")]
        public string Action { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Reason", Description = "Audit Vehicle Reason")]
        public string Reason { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Audit Vehicle Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Audit Vehicle Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}