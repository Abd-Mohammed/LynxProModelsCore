
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public enum SendingOption
    {
        [Display(Name = "GPRS")]
        Gprs = 1,
        [Display(Name = "SMS")]
        Sms = 2,
        [Display(Name = "CMS")]
        Cms = 3
    }

    public class DeviceCommand : TenantAware, ITenantAware
    {
        public int DeviceCommandId { get; set; }

        [Required]
        [Display(Name = "Name", Description = "Device Command Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Message", Description = "Device Command Message")]
        public string Message { get; set; }

        [MaxLength(50)]
        [Display(Name = "Vehicle Name", Description = "Device Command Vehicle Name")]
        public string VehicleName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Tracked Asset Name", Description = "Device Command Tracked Asset Name")]
        public string TrackedItemName { get; set; }

        [Required]
        [MaxLength(25)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Numeric Id", Description = "Device Command Numeric Id")]
        public string NumericId { get; set; }

        [Required]
        [MaxLength(25)]
        [Display(Name = "SIM Card No", Description = "Device Command SIM Card No")]
        [RegularExpression(@"^[^\-]\+?[\d -]+$", ErrorMessage = "The field {0} is invalid.")]
        public string SimCardNo { get; set; }

        [Range(1, 3, ErrorMessage = "The {0} field is required.")]
        [Display(Name = "Sent Option", Description = "Device Command Sent Option")]
        public SendingOption SentOption { get; set; }

        [Display(Name = "Is Success Status", Description = "Is Device Command Success Status")]
        public bool IsSuccessStatus { get; set; }

        [MaxLength(100)]
        [Display(Name = "Error Message", Description = "Device Command Error Message")]
        public string ErrorMessage { get; set; }

        [MaxLength(50)]
        [Display(Name = "Sent By", Description = "Device Command Sent By")]
        public string SentBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Sent Date", Description = "Device Command Sent Date")]
        public DateTime SentDate { get; set; }
    }
}