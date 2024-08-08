
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public enum CustomerGender
    {
        [Display(Name = "Male")]
        Male = 1,
        [Display(Name = "Female")]
        Female = 2
    }

    public class Customer : TenantAware, ITenantAware
    {
        public Customer()
        {
            CustomerAddresses = new HashSet<CustomerAddress>();
        }

        public int CustomerId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "First Name", Description = "Customer First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Last Name", Description = "Customer Last Name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Mobile No", Description = "Customer Mobile No")]
        [RegularExpression(StandardPhoneNoFormats.Default, ErrorMessage = "The field {0} is invalid.")]
        public string MobileNo { get; set; }

        [MaxLength(50)]
        [Display(Name = "Email", Description = "Customer Email")]
        [RegularExpression(StandardEmailFormats.Default, ErrorMessage = "You must enter a valid email address")]
        public string Email { get; set; }

        [Display(Name = "Is Verified", Description = "Is Customer Verified")]
        public bool IsVerified { get; set; }

        [Display(Name = "Is Active", Description = "Is Customer Active")]
        public bool IsActive { get; set; }

        [Range(1, 2)]
        [Display(Name = "Gender", Description = "Customer Gender")]
        public CustomerGender? Gender { get; set; }

        [Display(Name = "Date Of Birth", Description = "Customer Date Of Birth")]
        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        public DateTime? DateOfBirth { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Profile Picture", Description = "Customer Profile Picture")]
        public string ProfilePicture { get; set; }

        [Range(1, 5)]
        [Display(Name = "Rating", Description = "Customer Rating")]
        public double? Rating { get; set; }

        [Display(Name = "Preference Data", Description = "Customer Preference Data")]
        public string PreferenceData { get; set; }

        [Display(Name = "Home Latitude", Description = "Customer Home Latitude")]
        public double? HomeLatitude { get; set; }

        [Display(Name = "Home Longitude", Description = "Customer Home Longitude")]
        public double? HomeLongitude { get; set; }

        [MaxLength(250)]
        [Display(Name = "Home Address", Description = "Customer Home Address")]
        public string HomeAddress { get; set; }

        [Display(Name = "Work Latitude", Description = "Customer Work Latitude")]
        public double? WorkLatitude { get; set; }

        [Display(Name = "Work Longitude", Description = "Customer Work Longitude")]
        public double? WorkLongitude { get; set; }

        [MaxLength(250)]
        [Display(Name = "Work Address", Description = "Customer Work Address")]
        public string WorkAddress { get; set; }

        [Display(Name = "Is Lockout Enabled", Description = "Is Customer Lockout Enabled")]
        public bool IsLockoutEnabled { get; set; }

        [Display(Name = "Lockout End Date", Description = "Customer Lockout End Date")]
        public DateTime? LockoutEndDate { get; set; }

        [Display(Name = "Access Failed Count", Description = "Customer Access Failed Count")]
        public int AccessFailedCount { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Customer Created Date")]
        public DateTime CreatedDate { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Customer Modified Date")]
        public DateTime ModifiedDate { get; set; }

        public virtual CustomerDeviceInfo DeviceInfo { get; set; }
        public virtual CustomerPhoneVerification PhoneVerification { get; set; }
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }
}