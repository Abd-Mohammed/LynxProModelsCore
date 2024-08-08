using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class CustomerPhoneVerification
    {
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(6)]
        [RegularExpression("^[0-9]*$")]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Verification Code", Description = "Customer Phone Verification Code")]
        public string VerificationCode { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Verification Code Expiration Date", Description = "Customer Phone Verification Code Expiration Date")]
        public DateTime VerificationCodeExpirationDate { get; set; }

        [Display(Name = "Is Verified", Description = "Is Customer Phone Verification Verified")]
        public bool IsVerified { get; set; }

        [Range(0, 3)]
        [Display(Name = "Retry Count", Description = "Customer Phone Verification Retry Count")]
        public int RetryCount { get; set; }

        public virtual Customer Customer { get; set; }
    }
}