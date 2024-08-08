using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class User : TenantAware, ITenantAware
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Username", Description = "User Username")]
        public string Username { get; set; }

        [Required]
        [MaxLength(128)]
        [Display(Name = "Password", Description = "User Password")]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "First Name", Description = "User First Name")]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Second Name", Description = "User Second Name")]
        public string SecondName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Third Name", Description = "User Third Name")]
        public string ThirdName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Last Name", Description = "User Last Name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Mobile No", Description = "User Mobile No")]
        [RegularExpression(StandardPhoneNoFormats.Default, ErrorMessage = "The field {0} is invalid.")]
        public string MobileNo { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Email", Description = "User Email")]
        [RegularExpression(StandardEmailFormats.Default, ErrorMessage = "You must enter a valid email address")]
        public string Email { get; set; }

        [Display(Name = "Is Deactivated", Description = "Is User Deactivated")]
        public bool IsDeactivated { get; set; }

        [MaxLength(100)]
        [Display(Name = "Reset Password Token", Description = "User Reset Password Token")]
        public string ResetPasswordToken { get; set; }

        [Display(Name = "Reset Password Token Expiration Date", Description = "User Reset Password Token Expiration Date")]
        public DateTime? ResetPasswordTokenExpirationDate { get; set; }

        [Display(Name = "Is Lockout Enabled", Description = "Is User Lockout Enabled")]
        public bool IsLockoutEnabled { get; set; }

        [Display(Name = "Lockout End Date", Description = "User Lockout End Date")]
        public DateTime? LockoutEndDate { get; set; }

        [Display(Name = "Access Failed Count", Description = "User Access Failed Count")]
        public int AccessFailedCount { get; set; }

        [Display(Name = "Cookie Expiration Duration", Description = "User Cookie Expiration Duration (min)")]
        public int? CookieExpirationDuration { get; set; }

        [Display(Name = "Cookie Sliding Expiration", Description = "User Cookie Sliding Expiration")]
        public bool? CookieSlidingExpiration { get; set; }

        [Display(Name = "Is Fixed", Description = "Is User Fixed")]
        public bool IsFixed { get; set; }

        [Display(Name = "Last Activity Time", Description = "User Last Activity Time")]
        public DateTime? LastActivityTime { get; set; }

        public virtual UserSetting UserSetting { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}