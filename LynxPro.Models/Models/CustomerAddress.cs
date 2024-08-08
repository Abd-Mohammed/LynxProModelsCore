
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class CustomerAddress : TenantAware, ITenantAware
    {
        public int CustomerAddressId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Label", Description = "Customer Address Label")]
        public string Label { get; set; }

        [Display(Name = "Latitude", Description = "Customer Latitude")]
        public double Latitude { get; set; }

        [Display(Name = "Longitude", Description = "Customer Longitude")]
        public double Longitude { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Address Line 01", Description = "Customer Address Line 01")]
        public string AddressLine01 { get; set; }

        [MaxLength(250)]
        [Display(Name = "Address Line 02", Description = "Customer Address Line 02")]
        public string AddressLine02 { get; set; }

        [MaxLength(100)]
        [Display(Name = "City", Description = "Customer Address City")]
        public string City { get; set; }

        [MaxLength(100)]
        [Display(Name = "Zip Code", Description = "Customer Address Zip Code")]
        public string ZipCode { get; set; }

        [MaxLength(20)]
        [Display(Name = "Phone No", Description = "Customer Address Phone No")]
        [RegularExpression(StandardPhoneNoFormats.Default, ErrorMessage = "The field {0} is invalid.")]
        public string PhoneNo { get; set; }

        [MaxLength(250)]
        [Display(Name = "Instructions", Description = "Customer Address Instructions")]
        public string Instructions { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Customer Address Created Date")]
        public DateTime CreatedDate { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Customer Address Modified Date")]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "Customer", Description = "Customer Id")]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}