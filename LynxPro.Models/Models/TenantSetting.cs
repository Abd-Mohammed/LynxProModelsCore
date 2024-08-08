using LynxPro.Models.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public enum SystemOfMeasurement
    {
        [Display(Name = "Metric")]
        Metric = 1,
        [Display(Name = "Imperial")]
        Imperial = 2,
        [Display(Name = "Nautical")]
        Nautical = 3
    }

    public enum RfidConversionType
    {
        [Display(Name = "Non")]
        Non = 0,
    }

    public enum MobileDeviceAccessnType
    {
        [Display(Name = "Allow")]
        Allow = 1,
        [Display(Name = "Allow All")]
        AllowAll = 2,
        [Display(Name = "Deny")]
        Deny = 3,
        [Display(Name = "Deny All")]
        DenyAll = 4
    }

    public class TenantSetting : TenantAware, ITenantAware
    {
        public int TenantSettingId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Tenant Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Display Name", Description = "Tenant Display Name")]
        public string DisplayName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Short Name", Description = "Tenant Short Name")]
        public string ShortName { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Culture Name", Description = "Tenant Culture Name")]
        public string CultureName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Time Zone", Description = "Tenant Time Zone Id")]
        public string TimeZoneId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Device Time Zone", Description = "Tenant Device Time Zone Id")]
        public string DeviceTimeZoneId { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Geocoding Provider", Description = "Tenant geocoding service provider name")]
        public string GeocodingProvider { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Roads Provider", Description = "Tenant roads service provider name")]
        public string RoadsProvider { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Distance Matrix Provider", Description = "Tenant distance matrix service provider name")]
        public string DistanceMatrixProvider { get; set; }

        [Range(1, 3)]
        [Display(Name = "System Of Measurement", Description = "Tenant System Of Measurement")]
        public SystemOfMeasurement SystemOfMeasurement { get; set; }

        [Required]
        [MaxLength(5)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Currency", Description = "Tenant Currency")]
        public string Currency { get; set; }

        [Range(-90d, 90d)]
        [Display(Name = "Latitude", Description = "Tenant Latitude")]
        public double Latitude { get; set; }

        [Range(-180d, 180d)]
        [Display(Name = "Longitude", Description = "Tenant Longitude")]
        public double Longitude { get; set; }

        [Required]
        [MaxLength(3)]
        [Display(Name = "Region", Description = "Tenant Region")]
        public string Region { get; set; }

        [Display(Name = "Login Image Blob Name", Description = "Tenant Login Image Blob Name")]
        public string LoginImageBlobName { get; set; }

        [Display(Name = "Header Image Blob Name", Description = "Tenant Header Image Blob Name ")]
        public string HeaderImageBlobName { get; set; }

        [Display(Name = "Icon Blob Name", Description = "Tenant Icon Blob Name")]
        public string IconBlobName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Theme", Description = "Tenant Theme")]
        public string Theme { get; set; }

        [Required]
        [MaxLength(7)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Color", Description = "Tenant Color")]
        public string Color { get; set; }

        [Range(1, 4)]
        [Display(Name = "SMS Gateway", Description = "Tenant SMS Gateway")]
        public SmsGateway SmsGateway { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Automated Email", Description = "Tenant  Automated Email")]
        [RegularExpression(StandardEmailFormats.Default, ErrorMessage = "You must enter a valid email address")]
        public string AutomatedEmail { set; get; }

        [Display(Name = "Dashboard Shortcut Link", Description = "Tenant Dashboard Shortcut Link")]
        public bool ShowDashboardShortcutLink { get; set; }

        [Display(Name = "RFID Conversion Type", Description = "Tenant RFID Conversion Type")]
        public RfidConversionType RfidConversionType { get; set; }

        [Required]
        [Range(1, 4)]
        [Display(Name = "RFID Conversion Type", Description = "Tenant RFID Conversion Type")]
        public MobileDeviceAccessnType MobileDeviceAccess { get; set; }

        [Display(Name = "Mobile Device Access List", Description = "Tenant Mobile Device Access List")]
        [RegularExpression(StandardEmailFormats.MultiWithSemicolon, ErrorMessage = "You must enter a valid email address")]
        public string MobileDeviceAccessList { set; get; }

        [Display(Name = "Addon Configuration", Description = "Tenant Addon Configuration")]
        public string AddonConfiguration { get; set; }

        [Display(Name = "Deactivate After Inactivity", Description = "Tenant Deactivate After Inactivity")]
        public int? DeactivateAfterInactivity { get; set; }

        public string IntegrationDocument { get; set; }

        [NotMapped]
        public IEnumerable<Json.Addon> Addons { get { return JsonMapper.MapOrDefault<AddonConfig>(AddonConfiguration)?.Addons ?? Enumerable.Empty<Json.Addon>(); } }

        [NotMapped]
        public TenantIntegrationData Integration { get { return JsonMapper.MapOrDefault<TenantIntegrationData>(IntegrationDocument) ?? new TenantIntegrationData(); } }
    }
}
