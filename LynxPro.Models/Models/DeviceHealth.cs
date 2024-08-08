
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class DeviceHealth : TenantAware, ITenantAware
    {
        public DeviceHealth()
        {
            DeviceHealthAlertRules = new HashSet<DeviceHealthAlertRule>();
        }

        public int DeviceHealthId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Device Health Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Device Health Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Device Health Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Device Health Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Device Health Modified Date")]
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<DeviceHealthAlertRule> DeviceHealthAlertRules { get; set; }
    }
}