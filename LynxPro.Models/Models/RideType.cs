
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class RideType : TenantAware, ITenantAware, IIntegrationAware
    {
        public RideType()
        {
            RideTypeVehicleTypes = new HashSet<RideTypeVehicleType>();
        }

        public int RideTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Ride Type Name")]
        public string Name { get; set; }

        [MaxLength(250)]
        [Display(Name = "Description", Description = "Ride Type Description")]
        public string Description { get; set; }

        [Display(Name = "No Fare", Description = "No Ride Type Fare")]
        public bool NoFare { get; set; }

        [Display(Name = "No Request On Ride", Description = "No Ride Type Request On Ride")]
        public bool NoRequestOnRide { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Ride Type Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Ride Type Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Ride Type Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Ride Type Modified Date")]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "Passenger Count", Description = "Ride Type Passenger Count")]
        [Range(1, 10)]
        public int PassengerCount { get; set; }

        [Display(Name = "Integration Id", Description = "Ride Type Integration Id")]
        public int? IntegrationId { get; set; }

        public ICollection<RideTypeVehicleType> RideTypeVehicleTypes { get; set; }
        public int TenantId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}