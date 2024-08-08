using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class Vehicle : TenantAware, ITenantAware, ISoftDelete, IIntegrationAware
    {
        public Vehicle()
        {
            VehicleCrewMembers = new HashSet<VehicleCrewMember>();
            VehiclePeripherals = new HashSet<VehiclePeripheral>();
            DriverVehicles = new HashSet<DriverVehicle>();
        }

        public int VehicleId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Vehicle Name")]
        public string Name { get; set; }

        [MaxLength(50)]
        [Display(Name = "Number", Description = "Vehicle Number")]
        public string Number { get; set; }

        [Required]
        [MaxLength(25)]
        [Display(Name = "Make", Description = "Vehicle Make")]
        public string Make { get; set; }

        [Required]
        [MaxLength(25)]
        [Display(Name = "Model", Description = "Vehicle Model")]
        public string Model { get; set; }

        [Range(1900, 9999)]
        [Display(Name = "Year", Description = "Vehicle Year")]
        public int Year { get; set; }

        [Required]
        [MaxLength(25)]
        [Display(Name = "Color", Description = "Vehicle Color")]
        public string Color { get; set; }

        [MaxLength(25)]
        [Display(Name = "Engine No", Description = "Vehicle Engine No")]
        public string EngineNo { get; set; }

        [MaxLength(25)]
        [Display(Name = "Chassis No", Description = "Vehicle Chassis No")]
        public string ChassisNo { get; set; }

        [Required]
        [MaxLength(25)]
        [Display(Name = "Plate No", Description = "Vehicle Plate No")]
        public string PlateNo { get; set; }

        [Display(Name = "Vehicle Type", Description = "Vehicle Type Id")]
        public int VehicleTypeId { get; set; }

        [Display(Name = "Vehicle Condition", Description = "Vehicle Condition Id")]
        public int VehicleConditionId { get; set; }

        [Display(Name = "Vehicle Franchise", Description = "Vehicle Franchise Id")]
        public int? VehicleFranchiseId { get; set; }

        [Range(0, long.MaxValue)]
        [Display(Name = "Initial Odometer (m)", Description = "Vehicle Initial Odometer (m)")]
        public long? InitialOdometer { get; set; }

        [Range(0, 999999)]
        [Display(Name = "Initial Engine Hours", Description = "Vehicle Initial Engine Hours (m)")]
        public double? InitialEngineHours { get; set; }

        [MaxLength(50)]
        [Display(Name = "Custom Attribute 1", Description = "Vehicle Custom Attribute 1")]
        public string CustomAttribute1 { get; set; }

        [MaxLength(50)]
        [Display(Name = "Custom Attribute 2", Description = "Vehicle Custom Attribute 2")]
        public string CustomAttribute2 { get; set; }

        [MaxLength(50)]
        [Display(Name = "Custom Attribute 3", Description = "Vehicle Custom Attribute 3")]
        public string CustomAttribute3 { get; set; }

        [MaxLength(50)]
        [Display(Name = "Custom Attribute 4", Description = "Vehicle Custom Attribute 4")]
        public string CustomAttribute4 { get; set; }

        [MaxLength(50)]
        [Display(Name = "Custom Attribute 5", Description = "Vehicle Custom Attribute 5")]
        public string CustomAttribute5 { get; set; }

        [Display(Name = "Options", Description = "Vehicle Options")]
        public string Options { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Vehicle Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Vehicle Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Vehicle Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Vehicle Modified Date")]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "Assigned Zone", Description = "Assigned Zone Id")]
        public int? AssignedZoneId { get; set; }

        [Display(Name = "Primary Device", Description = "Primary Device Id")]
        public int? PrimaryDeviceId { get; set; }

        [Display(Name = "Secondary Device", Description = "Secondary Device Id")]
        public int? SecondaryDeviceId { get; set; }

        [Display(Name = "Integration Id", Description = "Vehicle Integration Id")]
        public int? IntegrationId { get; set; }

        [MaxLength(50)]
        [Display(Name = " Deleted By", Description = "Vehicle  Deleted By")]
        public string DeletedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = " Deleted Date", Description = "Vehicle  Deleted Date")]
        public DateTime? DeletedDate { get; set; }

        public bool IsDeleted { get; set; }

        [JsonIgnore]
        public virtual Device PrimaryDevice { get; set; }
        [JsonIgnore]
        public virtual Device SecondaryDevice { get; set; }
        [JsonIgnore]
        public virtual Area AssignedZone { get; set; }
        [JsonIgnore]
        public virtual VehicleType VehicleType { get; set; }
        [JsonIgnore]
        public virtual VehicleCondition VehicleCondition { get; set; }
        [JsonIgnore]
        public virtual VehicleFranchise VehicleFranchise { get; set; }
        [JsonIgnore]
        public virtual VehicleState VehicleState { get; set; }
        [JsonIgnore]
        public virtual VehicleQuarantine VehicleQuarantine { get; set; }
        [JsonIgnore]
        public virtual VehicleRideState VehicleRideState { get; set; }
        [JsonIgnore]
        public virtual VehicleHos VehicleHos { get; set; }
        [JsonIgnore]
        public virtual ICollection<VehicleCrewMember> VehicleCrewMembers { get; set; }
        [JsonIgnore]
        public virtual ICollection<VehiclePeripheral> VehiclePeripherals { get; set; }
        [JsonIgnore]
        public virtual ICollection<DriverVehicle> DriverVehicles { get; set; }
    }
}