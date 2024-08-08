
using LynxPro.Models.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class DeviceType : TenantAware, ITenantAware
    {
        public int DeviceTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Device Type Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Manufacturer", Description = "Device Type Manufacturer")]
        public string Manufacturer { get; set; }

        [Required]
        [Display(Name = "Metadata", Description = "Device Type Metadata")]
        public string Metadata { get; set; }

        [NotMapped]
        public DeviceTypeCapabilities Capabilities { get { return JsonMapper.Map<DeviceTypeMetadata>(Metadata).Capabilities; } }

        [NotMapped]
        public IdentType Ident { get { return JsonMapper.Map<DeviceTypeMetadata>(Metadata).Ident; } }

        [NotMapped]
        public DeviceTypeConfiguration Configuration { get { return JsonMapper.Map<DeviceTypeMetadata>(Metadata).Configuration; } }

        [NotMapped]
        public UIConfiguration UIConfiguration { get { return JsonMapper.Map<DeviceTypeMetadata>(Metadata).UIConfiguration; } }
    }
}