
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public enum FareDistanceUnit
    {
        [Display(Name = "Kilometer")]
        Kilometer = 1,
        [Display(Name = "Mile")]
        Mile = 2,
        [Display(Name = "Nautical Mile")]
        NauticalMile = 3
    }

    public class CityFare : TenantAware, ITenantAware, IIntegrationAware
    {
        public CityFare()
        {
            ExtraCharges = new HashSet<CityFareExtraCharge>();
            Transits = new HashSet<CityFareTransit>();
        }

        public int CityFareId { get; set; }

        [Range(0, 1000)]
        [Display(Name = "Base Fare", Description = "City Fare Base Fare")]
        public decimal BaseFare { get; set; }

        [Range(0, 1000)]
        [Display(Name = "Cost Per Minute", Description = "City Fare Cost Per Minute")]
        public decimal CostPerMinute { get; set; }

        [Range(0, 1000)]
        [Display(Name = "Cost Per Distance", Description = "City Fare Cost Per Distance")]
        public decimal CostPerDistance { get; set; }

        [Display(Name = "Distance Unit", Description = "City Fare Distance Unit")]
        public FareDistanceUnit DistanceUnit { get; set; }

        [Range(0, 1000)]
        [Display(Name = "Minimum Fare", Description = "City Minimum Fare")]
        public decimal MinimumFare { get; set; }

        [Range(0, 1000)]
        [Display(Name = "Booking Fee", Description = "City Fare Booking Fee")]
        public decimal BookingFee { get; set; }

        [Range(0, 1000)]
        [Display(Name = "Wait Time Charge Per Minute", Description = "City Fare Wait Time Charge Per Minute")]
        public decimal WaitTimeChargePerMinute { get; set; }

        [Range(0, 60)]
        [Display(Name = "Wait Time Threshold (min)", Description = "City Fare Wait Time Threshold (min)")]
        public int WaitTimeThreshold { get; set; }

        [Required]
        [MaxLength(3)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Currency Code", Description = "City Fare Currency Code")]
        public string CurrencyCode { get; set; }

        [Display(Name = "City", Description = "City Id")]
        public int CityId { get; set; }

        [Display(Name = "Ride Type", Description = "Ride Type Id")]
        public int RideTypeId { get; set; }

        [Display(Name = "Fare Schedule", Description = "Fare Schedule Id")]
        public int? FareScheduleId { get; set; }

        [Required]
        [MaxLength(7)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Color", Description = "City Fare Color")]
        public string Color { get; set; }

        [Display(Name = "Integration Id", Description = "Fare Integration Id")]
        public int? IntegrationId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Created By", Description = "City Fare Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "City Fare Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "City Fare Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "City Fare Modified Date")]
        public DateTime ModifiedDate { get; set; }

        public virtual City City { get; set; }
        public virtual RideType RideType { get; set; }
        public virtual FareSchedule FareSchedule { get; set; }
        public virtual ICollection<CityFareExtraCharge> ExtraCharges { get; set; }
        public virtual ICollection<CityFareTransit> Transits { get; set; }
    }
}