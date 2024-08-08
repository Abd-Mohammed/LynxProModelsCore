
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class EmailMessage : TenantAware, ITenantAware
    {
        public int EmailMessageId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Subject", Description = "Email Message Subject")]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "Body", Description = "Email Message Body")]
        public string Body { get; set; }

        [Required]
        [Display(Name = "To", Description = "Email Message To")]
        public string To { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Sent Date", Description = "Email Message Sent Date")]
        public DateTime SentDate { get; set; }
    }
}