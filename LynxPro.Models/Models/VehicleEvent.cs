using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public enum VehicleEventType
    {
        Breakdown = 1,
        Emergency = 2,
    }

    public enum VehicleEventSource
    {
        Physical = 1,
        Virtual = 2,
    }

    public class VehicleEvent : TenantAware, ITenantAware
    {
        public int VehicleEventId { get; set; }

        [Range(1, 2)]
        [Display(Name = "Type", Description = "Vehicle Event Type")]
        public VehicleEventType Type { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Time", Description = "Vehicle Event Time")]
        public DateTime Time { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Address", Description = "Vehicle Event Address")]
        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Vehicle Name", Description = "Vehicle Event Vehicle Name")]
        public string VehicleName { get; set; }

        [Required]
        [MaxLength(25)]
        [Display(Name = "Vehicle Plate No", Description = "Vehicle Event Vehicle Plate No")]
        public string VehiclePlateNo { get; set; }

        [MaxLength(10)]
        [Display(Name = "Staff Id", Description = "Vehicle Event Driver Staff Id")]
        public string DriverStaffId { get; set; }

        [MaxLength(50)]
        [Display(Name = "Driver First Name", Description = "Vehicle Event Driver First Name")]
        public string DriverFirstName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Driver Last Name", Description = "Vehicle Event Driver Last Name")]
        public string DriverLastName { get; set; }

        [Range(1, 2)]
        [Display(Name = "Source", Description = "Vehicle Event Source")]
        public VehicleEventSource Source { get; set; }
    }
}