
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class MaintenanceServiceType : TenantAware, ITenantAware
    {
        public int MaintenanceServiceTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Maintenance Service Type Name")]
        public string Name { get; set; }

        [MaxLength(250)]
        [Display(Name = "Description", Description = "Maintenance Service Type Description")]
        public string Description { get; set; }

        [Display(Name = "Is Full", Description = "Is Maintenance Service Type Full")]
        public bool IsFull { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Maintenance Service Type Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Maintenance Service Type Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Maintenance Service Type Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Maintenance Service Type Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}
