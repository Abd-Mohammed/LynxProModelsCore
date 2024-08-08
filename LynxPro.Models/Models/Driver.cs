
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public enum Gender
    {
        Male = 1,
        Female = 2
    }

    public class Driver : TenantAware, ITenantAware, IIntegrationAware
    {
        public Driver()
        {
            DriverShifts = new HashSet<DriverShift>();
            DriverVehicles = new HashSet<DriverVehicle>();
            DriverVehicleTypes = new HashSet<DriverVehicleType>();
        }

        public int DriverId { get; set; }

        [Required]
        [MaxLength(10)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Staff Id", Description = "Driver Staff Id")]
        [RegularExpression("[a-zA-Z0-9]{5,10}", ErrorMessage = "The field {0} is invalid.")]
        public string StaffId { get; set; }

        [MaxLength(25)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Smart Card UID", Description = "Driver Smart Card UID")]
        public string SmartCardUid { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Username", Description = "Driver Username")]
        public string Username { get; set; }

        [Required]
        [MaxLength(128)]
        [Display(Name = "Password", Description = "Driver Password")]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "First Name", Description = "Driver First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Last Name", Description = "Driver Last Name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Mobile No", Description = "Driver Mobile No")]
        [RegularExpression(StandardPhoneNoFormats.DefaultOrZeroes, ErrorMessage = "The field {0} is invalid.")]
        public string MobileNo { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Email", Description = "Driver Email")]
        [RegularExpression(StandardEmailFormats.Default, ErrorMessage = "You must enter a valid email address")]
        public string Email { get; set; }

        [Required]
        [MaxLength(4)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "PIN Number", Description = "Driver PIN Number")]
        [RegularExpression("^\\d{4}$", ErrorMessage = "The field {0} is invalid.")]
        public string PinNumber { get; set; }

        [MaxLength(25)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "License Number", Description = "Driver License Number")]
        [RegularExpression("[a-zA-Z0-9]{5,10}", ErrorMessage = "The field {0} is invalid.")]
        public string LicenseNumber { get; set; }

        [MaxLength(25)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Permit Id", Description = "Driver Permit Id")]
        [RegularExpression("[a-zA-Z0-9]{5,10}", ErrorMessage = "The field {0} is invalid.")]
        public string PermitId { get; set; }

        [MaxLength(25)]
        [Display(Name = "Nationality", Description = "Driver Nationality")]
        public string Nationality { get; set; }

        [Display(Name = "Options", Description = "Driver Options")]
        public string Options { get; set; }

        [MaxLength(100)]
        [Display(Name = "Image Blob Name", Description = "Driver Image Blob Name")]
        public string ImageBlobName { get; set; }

        [Display(Name = "Is Available", Description = "Is Available")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Any Time Allowed", Description = "Driver Any Time Allowed")]
        public bool AnyTimeAllowed { get; set; }

        [Display(Name = "Any Vehicle Allowed", Description = "Driver Any Vehicle Allowed")]
        public bool AnyVehicleAllowed { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Driver Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Driver Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Driver Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Driver Modified Date")]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "Integration Id", Description = "Driver Integration Id")]
        public int? IntegrationId { get; set; }

        [Display(Name = "Gender", Description = "Driver Gender")]
        public Gender? Gender { get; set; }

        public virtual DriverSetting DriverSetting { get; set; }
        public virtual DriverHos DriverHos { get; set; }
        public virtual DriverBalance Balance { get; set; }
        public virtual ICollection<DriverShift> DriverShifts { get; set; }
        public virtual ICollection<DriverVehicle> DriverVehicles { get; set; }
        public virtual ICollection<DriverVehicleType> DriverVehicleTypes { get; set; }
        public virtual DriverRideStatistics RideStatistics { get; set; }
    }
}