using LynxPro.Models.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public enum VehiclePeripheralType
    {
        [Display(Name = "Mobile")]
        Mobile = 1,
    }

    public class VehiclePeripheral : TenantAware, ITenantAware
    {
        public int VehiclePeripheralId { get; set; }

        [Display(Name = "Vehicle", Description = "Vehicle Id")]
        public int VehicleId { get; set; }

        [Display(Name = "Vehicle Peripheral Type", Description = "Vehicle Peripheral Type")]
        public VehiclePeripheralType Type { get; set; }

        [Display(Name = "Data", Description = "Vehicle Peripheral Data")]
        public string Data { get; set; }

        [Display(Name = "Details", Description = "Vehicle Peripheral Details")]
        public string Details { get; set; }

        [NotMapped]
        public Mobile MobileData { get { return JsonMapper.MapOrDefault<Mobile>(Data); } }

        public virtual Vehicle Vehicle { get; set; }
    }
}