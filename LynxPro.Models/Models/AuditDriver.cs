
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class AuditDriver : TenantAware, ITenantAware
    {
        public int AuditDriverId { get; set; }

        [Required]
        [MaxLength(10)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Staff Id", Description = "Audit Driver Staff Id")]
        [RegularExpression("[a-zA-Z0-9]{5,10}", ErrorMessage = "The field {0} is invalid.")]
        public string StaffId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "First Name", Description = "Driver First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Last Name", Description = "Audit Driver Last Name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Action", Description = "Audit Driver Action")]
        public string Action { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Reason", Description = "Audit Driver Reason")]
        public string Reason { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Audit Driver Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Audit Driver Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}