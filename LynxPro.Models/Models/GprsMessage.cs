
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public enum GprsProtocolStack
    {
        /// <summary>
        /// Flespi HTTP APIs
        /// </summary>
        Flespi = 1,
        /// <summary>
        /// Message-oriented Middleware such as Azure service bus, Apache ActiveMQ, etc..
        /// </summary>
        Mom = 2
    }

    public class GprsMessage : TenantAware, ITenantAware
    {
        public int GprsMessageId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Unique ID", Description = "GPRS Message Unique ID")]
        public string Sid { get; set; }

        [Range(1, 2)]
        [Display(Name = "Protocol Stack", Description = "GPRS Message Protocol Stack")]
        public GprsProtocolStack ProtocolStack { get; set; }

        [Required]
        [MaxLength(25)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Numeric Id", Description = "GPRS Message Device Numeric Id")]
        public string DeviceNumericId { get; set; }

        [Display(Name = "Channel Id", Description = "GPRS Message Channel Id")]
        public int? ChannelId { get; set; }

        [MaxLength(50)]
        [Display(Name = "Queue Name", Description = "GPRS Message Queue Name")]
        public string QueueName { get; set; }

        [Required]
        [Display(Name = "Payload", Description = "GRPS Message Payload")]
        public string Payload { get; set; }

        [MaxLength(50)]
        [Display(Name = "Sent By", Description = "GPRS Message Sent By")]
        public string SentBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Sent Date", Description = "GPRS Message Created Date")]
        public DateTime SentDate { get; set; }
    }
}