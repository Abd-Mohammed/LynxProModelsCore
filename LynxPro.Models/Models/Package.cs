
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class Package : TenantAware, ITenantAware
    {
        public int PackageId { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^(?=.*[A-Za-z])[a-zA-Z0-9\\-]*$", ErrorMessage = "The field {0} is invalid, {0} must contain at least one alphanumeric characters and hyphens only.")]
        [Display(Name = "Name", Description = "Package Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Display Name", Description = "Package Display Name")]
        public string DisplayName { get; set; }

        [MaxLength(250)]
        [Display(Name = "Description", Description = "Package Description")]
        public string Description { get; set; }

        [Range(1, 100000)]
        [Display(Name = "Weight", Description = "Package Weight")]
        public int Weight { get; set; }

        [Range(1, 100000)]
        [Display(Name = "Volume", Description = "Package Volume")]
        public int Volume { get; set; }

        [Range(1d, 100000d)]
        [Display(Name = "Value", Description = "Package Value")]
        public double? Value { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Package Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Package Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Package Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Package Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}