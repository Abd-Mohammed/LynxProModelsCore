using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class VehicleFranchise : TenantAware, ITenantAware, IIntegrationAware
    {
        public int VehicleFranchiseId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Vehicle Franchise Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Contact Name", Description = "Vehicle Franchise Contact Name")]
        public string ContactName { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Contact Phone No", Description = "Vehicle Franchise Contact Phone No")]
        [RegularExpression(StandardPhoneNoFormats.Default, ErrorMessage = "The field {0} is invalid.")]
        public string ContactPhoneNo { get; set; }

        [Required]
        [MaxLength(7)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Color", Description = "Vehicle Franchise Color")]
        public string Color { get; set; }

        [Required]
        [Display(Name = "Image Blob Name", Description = "Vehicle Franchise Image Blob Name")]
        public string ImageBlobName { get; set; }

        [Display(Name = "Integration Id", Description = "Vehicle Franchise Integration Id")]
        public int? IntegrationId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Vehicle Franchise Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Vehicle Franchise Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Vehicle Franchise Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Vehicle Franchise Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}