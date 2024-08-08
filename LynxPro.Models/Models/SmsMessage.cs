
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class SmsMessage : TenantAware, ITenantAware
    {
        public long SmsMessageId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Unique ID", Description = "SMS Message Unique ID")]
        public string Sid { get; set; }

        [Required]
        [Display(Name = "Body", Description = "SMS Message Body")]
        public string Body { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Recipient Name", Description = "SMS Message Recipient Name")]
        public string RecipientName { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Recipient Mobile No", Description = "SMS Message Recipient Mobile No")]
        [RegularExpression(StandardPhoneNoFormats.Default, ErrorMessage = "The field {0} is invalid.")]
        public string RecipientMobileNo { get; set; }

        [Range(1, 4)]
        [Display(Name = "Sms Gateway", Description = "SMS Message Gateway")]
        public SmsGateway Gateway { get; set; }

        [Required]
        [Range(1, 17)]
        [Display(Name = "Status", Description = "SMS Message Status")]
        public SmsStatusCode Status { get; set; }

        [Range(1, 2)]
        [Display(Name = "Type", Description = "SMS Message Type")]
        public SmsType Type { get; set; }

        [MaxLength(50)]
        [Display(Name = "Sent By", Description = "SMS Message Sent By")]
        public string SentBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Sent Date", Description = "SMS Message Created Date")]
        public DateTime SentDate { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]

        [Display(Name = "Delivered Date", Description = "SMS Message Delivered Date")]
        public DateTime? DeliveredDate { get; set; }

        [Display(Name = "Retry Count", Description = "SMS Message Retry Count")]
        public int RetryCount { get; set; }

        public bool IsSuccessStatusCode()
        {
            return this.Status == SmsStatusCode.DeliveredToGateway ||
                this.Status == SmsStatusCode.ReceivedByRecipient ||
                this.Status == SmsStatusCode.MessageQueued;
        }
    }

    public enum SmsStatusCode
    {
        // The message ID is incorrect, not found or reporting is delayed. Note that a message can only be queried up to six days after it has been submitted to our gateway.
        [Display(Name = "Message Unknown")]
        MessageUnknown = 1,
        // The message could not be delivered and has been queued for attempted redelivery.
        [Display(Name = "Message Queued")]
        MessageQueued = 2,
        // Delivered to the upstream gateway or network (delivered to the recipient).
        [Display(Name = "Delivered To Gateway")]
        DeliveredToGateway = 3,
        // Confirmation of receipt on the handset of the recipient.
        [Display(Name = "Received By Recipient")]
        ReceivedByRecipient = 4,
        // There was an error with the message, probably caused by the content of the message itself.
        [Display(Name = "Error With Message")]
        ErrorWithMessage = 5,
        // The message was terminated by a user (stop message command).
        [Display(Name = "User Cancelled Message Delivery")]
        UserCancelledMessageDelivery = 6,
        // An error occurred delivering the message to the handset.
        [Display(Name = "Error Delivering Message")]
        ErrorDeliveringMessage = 7,
        // An error occurred while attempting to route the message.
        [Display(Name = "Routing Error")]
        RoutingError = 8,
        // Message expired before we were able to deliver it to the upstream gateway. No charge applies.
        [Display(Name = "Message Expired")]
        MessageExpired = 9,
        // Message has been scheduled for delivery at a later time (delayed delivery feature).
        [Display(Name = "Message Scheduled For Later Delivery")]
        MessageScheduledForLaterDelivery = 10,
        // The message cannot be delivered due to insufficient credits.
        [Display(Name = "Out Of Credit")]
        OutOfCredit = 11,
        // The message was terminated by our staff.
        [Display(Name = "Cancelled Message Delivery")]
        CancelledMessageDelivery = 12,
        // The allowable amount for MT messaging has been exceeded.
        [Display(Name = "Maximum MT Limit Exceeded")]
        MaximumMtLimitExceeded = 13,
        // Other.
        [Display(Name = "Other")]
        Other = 14,
        [Display(Name = "Quota Exceeded")]
        QuotaExceeded = 15,
        [Display(Name = "Message Missing MSISDN")]
        MessageMissingMsisdn = 16,
        [Display(Name = "Message Missing ICCID")]
        MessageMissingIccid = 17,
        [Display(Name = "Invalid ICCID")]
        InvalidIccid = 18
    }
    public enum SmsGateway
    {
        [Display(Name = "Clickatell")]
        Clickatell = 1,
        [Display(Name = "Smart SMS")]
        SmartSms = 2,
        [Display(Name = "Value First")]
        ValueFirst = 3,
        [Display(Name = "Etisalat")]
        Etisalat = 4
    }
    public enum SmsType
    {
        [Display(Name = "SMS")]
        Sms = 1,
        [Display(Name = "MMS")]
        Mms = 2,
    }
}