
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class CrewMember : TenantAware, ITenantAware
    {
        public CrewMember()
        {
            CrewMemberShifts = new HashSet<CrewMemberShift>();
            CrewMemberVehicleTypes = new HashSet<CrewMemberVehicleType>();
        }

        public int CrewMemberId { get; set; }

        [Required]
        [MaxLength(10)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Staff Id", Description = "Crew Member Staff Id")]
        [RegularExpression("[a-zA-Z0-9]{5,10}", ErrorMessage = "The field {0} is invalid.")]
        public string StaffId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "First Name", Description = "Crew Member First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Last Name", Description = "Crew Member Last Name")]
        public string LastName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Nationality", Description = "Crew Member Nationality")]
        public string Nationality { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Mobile No", Description = "Crew Member Mobile No")]
        [RegularExpression(StandardPhoneNoFormats.Default, ErrorMessage = "The field {0} is invalid.")]
        public string MobileNo { get; set; }

        [MaxLength(50)]
        [Display(Name = "Email", Description = "Crew Member Email")]
        [RegularExpression(StandardEmailFormats.Default, ErrorMessage = "You must enter a valid email address")]
        public string Email { get; set; }

        [Display(Name = "Is Available", Description = "Is Available")]
        public bool IsAvailable { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Crew Member Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Crew Member Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Crew Member Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Crew Member Modified Date")]
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<CrewMemberShift> CrewMemberShifts { get; set; }
        public virtual ICollection<CrewMemberVehicleType> CrewMemberVehicleTypes { get; set; }
    }
}