
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class RideInvoiceTemplate : TenantAware, ITenantAware
    {
        public int RideInvoiceTemplateId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Ride Invoice Template Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Html", Description = "Ride Invoice Template Html")]
        public string Html { get; set; }

        [Display(Name = "Is Enabled", Description = "Is Ride Invoice Template Enabled")]
        public bool IsEnabled { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Ride Invoice Template Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Ride Invoice Template Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Ride Invoice Template Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Ride Invoice Template Modified Date")]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "Vehicle Franchise Id", Description = "Vehicle Franchise")]
        public int? VehicleFranchiseId { get; set; }

        public virtual VehicleFranchise VehicleFranchise { get; set; }
    }
}