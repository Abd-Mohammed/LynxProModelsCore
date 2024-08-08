
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public enum DeviceMessageStatus
    {
        [Display(Name = "Sent")]
        Sent = 1,
        [Display(Name = "Recieved")]
        Recieved = 2,
        [Display(Name = "Read")]
        Read = 3,
        [Display(Name = "Acknowledged")]
        Acknowledged = 4,
        [Display(Name = "Discarded")]
        Discarded = 5
    }

    public class DeviceMessage : TenantAware, ITenantAware, IFranchiseAware
    {
        public int DeviceMessageId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Unique ID", Description = "Device Message Unique ID")]
        public string Sid { get; set; }

        [Range(1, 5)]
        [Display(Name = "Status", Description = "Device Message Status")]
        public DeviceMessageStatus Status { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Subject", Description = "Device Message Subject")]
        public string Subject { get; set; }

        [Required]
        [MaxLength(300)]
        [Display(Name = "Body", Description = "Device Message Body")]
        public string Body { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Vehicle Name", Description = "Device Message Vehicle Name")]
        public string VehicleName { get; set; }

        [Required]
        [MaxLength(25)]
        [Display(Name = "Vehicle Plate No", Description = "Device Message Vehicle Plate No")]
        public string VehiclePlateNo { get; set; }

        [Required]
        [MaxLength(25)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Device Numeric Id", Description = "Device Message Device Numeric Id")]
        public string DeviceNumericId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Sent By", Description = "Device Message Sent By")]
        public string SentBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Sent Date", Description = "Device Message Sent Date")]
        public DateTime SentDate { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Recieved Date", Description = "Device Message Recieved Date")]
        public DateTime? RecievedDate { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Read Date", Description = "Device Message Read Date")]
        public DateTime? ReadDate { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Acknowledged Date", Description = "Device Message Acknowledged Date")]
        public DateTime? AcknowledgedDate { get; set; }
        public int FranchiseId { get; set; }
    }
}