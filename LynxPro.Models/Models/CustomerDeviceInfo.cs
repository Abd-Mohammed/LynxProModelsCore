using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public enum DeviceIdiom
    {
        [Display(Name = "Unknown")]
        Unknown = 0,
        [Display(Name = "Phone")]
        Phone = 1,
        [Display(Name = "Tablet")]
        Tablet = 2,
        [Display(Name = "Desktop")]
        Desktop = 3,
        [Display(Name = "TV")]
        Tv = 4,
        [Display(Name = "Watch")]
        Watch = 5
    }

    public enum DevicePlatform
    {
        [Display(Name = "Unknown")]
        Unknown = 0,
        [Display(Name = "Android")]
        Android = 1,
        [Display(Name = "iOS")]
        iOS = 2,
        [Display(Name = "UWP")]
        Uwp = 3
    }

    public class CustomerDeviceInfo
    {
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Model", Description = "Customer Device Model")]
        public string Model { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Manufacturer", Description = "Customer Device Manufacturer")]
        public string Manufacturer { get; set; }

        [Required]
        [Range(0, 3)]
        [Display(Name = "Platform", Description = "Customer Device Platform")]
        public DevicePlatform Platform { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Version", Description = "Customer Device Version")]
        public string Version { get; set; }

        [Required]
        [Range(0, 5)]
        [Display(Name = "Idiom", Description = "Customer Device Idiom")]
        public DeviceIdiom Idiom { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "UDID", Description = "Customer Device UDID")]
        public string Udid { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Registration Token", Description = "Customer Device Registration Token")]
        public string RegistrationToken { get; set; }

        public virtual Customer Customer { get; set; }
    }
}