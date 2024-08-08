using LynxPro.Models.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public enum RideSource
    {
        [Display(Name = "Customer")]
        Customer = 1,
        [Display(Name = "Call Center")]
        CallCenter = 2,
        [Display(Name = "Call Center (Manual)")]
        ManualAssignment = 3,
        [Display(Name = "Roadside")]
        Roadside = 4,
        [Display(Name = "External")]
        External = 5,
        [Display(Name = "Unrecognized")]
        Unrecognized = 6,
        [Display(Name = "Go")]
        Go = 7
    }

    public enum RideStatus
    {
        [Display(Name = "Accepted")]
        Accepted = 1,
        [Display(Name = "On Way")]
        OnWay = 2,
        [Display(Name = "Reached Customer")]
        ReachedCustomer = 3,
        [Display(Name = "Canceled")]
        Canceled = 4,
        [Display(Name = "Customer No Show")]
        CustomerNoShow = 5,
        [Display(Name = "Customer No Answer")]
        CustomerNoAnswer = 6,
        [Display(Name = "In Progress")]
        InProgress = 7,
        [Display(Name = "Completed")]
        Completed = 8,
        [Display(Name = "Discarded")]
        Discarded = 9
    }

    public class Ride : TenantAware, ITenantAware, IFranchiseAware
    {
        private RideTrip trip;

        public int RideId { get; set; }
        public int FranchiseId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Code", Description = "Ride Code")]
        public string Code { get; set; }

        [Range(1, 7)]
        [Display(Name = "Source", Description = "Ride Source")]
        public RideSource Source { get; set; }

        [Range(1, 9)]
        [Display(Name = "Status", Description = "Ride Status")]
        public RideStatus Status { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Request Time", Description = "Ride Request Time")]
        public DateTime RequestTime { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Accepted Time", Description = "Ride Accepted Time")]
        public DateTime? AcceptedTime { get; set; }

        // Pick up properties

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Expected Pickup Time", Description = "Ride Expected Pickup Time")]
        public DateTime ExpectedPickupTime { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Expected Pickup Address", Description = "Ride Expected Pickup Address")]
        public string ExpectedPickupAddress { get; set; }

        [Display(Name = "Expected Pickup Latitude", Description = "Ride Expected Pickup Latitude")]
        public double ExpectedPickupLatitude { get; set; }

        [Display(Name = "Expected Pickup Longitude", Description = "Ride Expected Pickup Longitude")]
        public double ExpectedPickupLongitude { get; set; }

        // Drop-off properties

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Expected Dropoff Time", Description = "Ride Expected Dropoff Time")]
        public DateTime ExpectedDropoffTime { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Expected Dropoff Address", Description = "Ride Expected Dropoff Address")]
        public string ExpectedDropoffAddress { get; set; }

        [Display(Name = "Expected Dropoff Latitude", Description = "Ride Expected Dropoff Latitude")]
        public double ExpectedDropoffLatitude { get; set; }

        [Display(Name = "Expected Dropoff Longitude", Description = "Ride Expected Dropoff Longitude")]
        public double ExpectedDropoffLongitude { get; set; }

        // Expected properties

        [Display(Name = "Expected Distance", Description = "Ride Expected Distance")]
        public long ExpectedDistance { get; set; }

        [Display(Name = "Expected Duration", Description = "Ride Expected Duration")]
        public long ExpectedDuration { get; set; }

        [Display(Name = "Expected Fare", Description = "Ride Expected Fare")]
        public decimal ExpectedFare { get; set; }

        [Display(Name = "Expected Discount", Description = "Ride Expected Discount")]
        public decimal ExpectedDiscount { get; set; }

        [Required]
        [MaxLength(3)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Expected Fare Currency Code", Description = "Ride Expected Fare Currency Code")]
        public string ExpectedFareCurrencyCode { get; set; }

        // Reached properties
        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Reached Time", Description = "Ride Reached Time")]
        public DateTime ReachedTime { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Reached Address", Description = "Ride Reached Address")]
        public string ReachedAddress { get; set; }

        [Display(Name = "Reached Latitude", Description = "Ride Reached Latitude")]
        public double ReachedLatitude { get; set; }

        [Display(Name = "Reached Longitude", Description = "Ride Reached Longitude")]
        public double ReachedLongitude { get; set; }

        // Start properties
        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Pickup Time", Description = "Ride Pickup Time")]
        public DateTime PickupTime { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Pickup Address", Description = "Ride Pickup Address")]
        public string PickupAddress { get; set; }

        [Display(Name = "Pickup Latitude", Description = "Ride Pickup Latitude")]
        public double PickupLatitude { get; set; }

        [Display(Name = "Pickup Longitude", Description = "Ride Pickup Longitude")]
        public double PickupLongitude { get; set; }

        // Drop-off properties

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Dropoff Time", Description = "Ride Dropoff Time")]
        public DateTime DropoffTime { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Dropoff Address", Description = "Ride Dropoff Address")]
        public string DropoffAddress { get; set; }

        [Display(Name = "Dropoff Latitude", Description = "Ride Dropoff Latitude")]
        public double DropoffLatitude { get; set; }

        [Display(Name = "Dropoff Longitude", Description = "Ride Dropoff Longitude")]
        public double DropoffLongitude { get; set; }

        // Actual properties

        [Display(Name = "Distance", Description = "Ride Distance")]
        public long Distance { get; set; }

        [Display(Name = "Duration", Description = "Ride Duration")]
        public long Duration { get; set; }

        [Display(Name = "Net Fare", Description = "Ride Net Fare")]
        public decimal NetFare { get; set; }

        [Display(Name = "Discount", Description = "Ride Discount")]
        public decimal Discount { get; set; }

        [Display(Name = "Total Fare", Description = "Ride Total Fare")]
        public decimal TotalFare { get; set; }

        [Required]
        [MaxLength(3)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Fare Currency Code", Description = "Ride Fare Currency Code")]
        public string FareCurrencyCode { get; set; }

        // Remaining Properties

        [Display(Name = "Last Status Updated By", Description = "Ride Last Status Updated By")]
        public string LastStatusUpdatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Last Status Updated Time", Description = "Ride Last Status Updated Time")]
        public DateTime LastStatusUpdatedTime { get; set; }

        [MaxLength(250)]
        [Display(Name = "Remarks", Description = "Ride Remarks")]
        public string Remarks { get; set; }

        [Display(Name = "No Dropoff Set", Description = "Ride No Dropoff Set")]
        public bool NoDropoffSet { get; set; }

        [Required]
        [Display(Name = "Trip Document", Description = "Ride Trip Document")]
        public string TripDocument { get; set; }

        [Display(Name = "Driver", Description = "Driver Id")]
        public int DriverId { get; set; }

        [Display(Name = "Vehicle", Description = "Vehicle Id")]
        public int VehicleId { get; set; }

        [Display(Name = "Customer", Description = "Customer Id")]
        public int? CustomerId { get; set; }

        [MaxLength(15)]
        [Display(Name = "Cancel Reason", Description = "Ride Cancel Reason Code")]
        public string CancelReasonCode { get; set; }

        [Range(1, 5)]
        [Display(Name = "Passenger Rating", Description = "Ride Passenger Rating")]
        public double? PassengerRating { get; set; }

        [MaxLength(250)]
        [Display(Name = "Passenger Rating Comment", Description = "Ride Passenger Rating Comment")]
        public string PassengerRatingComment { get; set; }

        [MaxLength(50)]
        [Display(Name = "Promo Code Name", Description = "Ride Promo Code Name")]
        public string PromoCodeName { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Promo Code Number", Description = "Ride Promo Code Number")]
        public string PromoCodeNumber { get; set; }

        [Display(Name = "Request", Description = "Request Id")]
        public int? RequestId { get; set; }

        [Display(Name = "Integration Id", Description = "Vehicle Integration Id")]
        public int? IntegrationId { get; set; }

        [Display(Name = "Has Go Promo Code")]
        public bool? HasGoPromoCode { get; set; }

        public bool Ongoing()
        {
            return Status == RideStatus.Accepted
                || Status == RideStatus.OnWay
                || Status == RideStatus.ReachedCustomer
                || Status == RideStatus.InProgress;
        }

        public virtual Driver Driver { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual RideRequest Request { get; set; }

        [NotMapped]
        public RideTrip Trip
        {
            get
            {
                if (trip == null)
                {
                    trip = JsonMapper.Map<RideTrip>(TripDocument);
                    return trip;
                }
                else
                {
                    return trip;
                }
            }
            set
            {
                trip = value;
            }
        }
    }
}