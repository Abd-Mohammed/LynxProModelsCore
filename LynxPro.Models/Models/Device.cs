
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public enum DeviceCommunication
    {
        [Display(Name = "Allow")]
        Allow = 1,
        [Display(Name = "Block")]
        Block = 2
    }

    public enum DeviceUsageMode
    {
        [Display(Name = "None")]
        None = 0,
        [Display(Name = "IoT")]
        Iot = 1
    }

    public class Device : TenantAware, ITenantAware
    {
        public int DeviceId { get; set; }

        [Required]
        [MaxLength(25)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Numeric Id", Description = "Device Numeric Id")]
        public string NumericId { get; set; }

        [MaxLength(25)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "IMEI", Description = "Device IMEI")]
        [RegularExpression("^([a-zA-Z0-9]){1,15}$", ErrorMessage = "The field {0} is invalid.")]
        public string Imei { get; set; }

        [MaxLength(25)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Serial No", Description = "Device Serial No")]
        [RegularExpression(@"^(?!\-|\+|\@|\*|\=|\\|\/).+", ErrorMessage = "[[[[The]]]] {0} [[[[can not start with invalid character]]]]")]
        public string SerialNo { get; set; }

        [Range(1, 2)]
        [Display(Name = "Communication", Description = "Device Communication")]
        public DeviceCommunication Communication { get; set; }

        [Range(0, 1)]
        [Display(Name = "Usage Mode", Description = "Device Usage Mode")]
        public DeviceUsageMode UsageMode { get; set; }

        [MaxLength(50)]
        [Display(Name = "Custom Attribute 1", Description = "Device Custom Attribute 1")]
        public string CustomAttribute1 { get; set; }

        [MaxLength(50)]
        [Display(Name = "Custom Attribute 2", Description = "Device Custom Attribute 2")]
        public string CustomAttribute2 { get; set; }

        [MaxLength(50)]
        [Display(Name = "Custom Attribute 3", Description = "Device Custom Attribute 3")]
        public string CustomAttribute3 { get; set; }

        [MaxLength(50)]
        [Display(Name = "Custom Attribute 4", Description = "Device Custom Attribute 4")]
        public string CustomAttribute4 { get; set; }

        [MaxLength(50)]
        [Display(Name = "Custom Attribute 5", Description = "Device Custom Attribute 5")]
        public string CustomAttribute5 { get; set; }

        [Display(Name = "Metadata", Description = "Device Metadata")]
        public string Metadata { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Device Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Device Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Device Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Device Modified Date")]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "Sim Card", Description = "Sim Card Id")]
        public int? SimCardId { get; set; }

        [Display(Name = "Device Type", Description = "Device Type Id")]
        public int DeviceTypeId { get; set; }

        public virtual SimCard SimCard { get; set; }
        [JsonIgnore]
        public virtual DeviceType DeviceType { get; set; }
        public virtual ICollection<Vehicle> PrimaryVehicles { get; set; }
        public virtual ICollection<Vehicle> SecondaryVehicles { get; set; }
        public virtual ICollection<TrackedItem> TrackedItems { get; set; }
    }
}