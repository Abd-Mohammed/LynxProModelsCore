using LynxPro.Models.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class UserSetting : TenantAware, ITenantAware
    {
        [Required]
        [MaxLength(10)]
        [Display(Name = "Culture Name", Description = "User Setting Culture Name")]
        public string CultureName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Time Zone", Description = "User Setting Time Zone Id")]
        public string TimeZoneId { get; set; }

        [Range(-90d, 90d)]
        [Display(Name = "Latitude", Description = "User Setting Latitude")]
        public double Latitude { get; set; }

        [Range(-180d, 180d)]
        [Display(Name = "Longitude", Description = "User Setting Longitude")]
        public double Longitude { get; set; }

        [Range(1, 60)]
        [Display(Name = "Request Rate (min)", Description = "User Setting Request Rate (min)")]
        public int RequestRate { get; set; }

        [MaxLength(50)]
        [Display(Name = "Default Page", Description = "User Setting Default Page")]
        public string DefaultPage { get; set; }

        [Required]
        [MaxLength(5)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Display Language", Description = "User Setting Display Language")]
        public string DisplayLanguage { get; set; }

        [MaxLength(25)]
        [Display(Name = "Default Map Type", Description = "User Setting Default Map Type")]
        public string DefaultMapType { get; set; }

        [Range(1, 8)]
        [Display(Name = "Video Default Channel", Description = "User Setting Video Default Channel")]
        public int VideoDefaultChannel { get; set; }

        [Display(Name = "Video Auto Play", Description = "User Setting Video Auto Play")]
        public bool VideoAutoPlay { get; set; }

        [Display(Name = "Mobile Device Configuration", Description = "User Mobile Device Configuration")]
        public string MobileDeviceConfiguration { get; set; }

        public int UserId { get; set; }

        [NotMapped]
        public IEnumerable<MobileDevice> MobileDevices { get { return JsonMapper.MapOrDefault<List<MobileDevice>>(MobileDeviceConfiguration) ?? Enumerable.Empty<MobileDevice>(); } }

        public virtual User User { get; set; }
    }
}