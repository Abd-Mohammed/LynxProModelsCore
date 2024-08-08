using LynxPro.Models.Json;
using LynxPro.Models.Utils;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public enum RideRequestStatus
    {
        [Display(Name = "None")]
        None = 0,
        [Display(Name = "Open")]
        Open = 1,
        [Display(Name = "Searching")]
        Searching = 2,
        [Display(Name = "Driver Response Pending")]
        DriverResponsePending = 3,
        [Display(Name = "Accepted")]
        Accepted = 4,
        [Display(Name = "Rejected")]
        Rejected = 5,
        [Display(Name = "Driver No Response")]
        DriverNoResponse = 6,
        [Display(Name = "Driver Response Timeout")]
        DriverResponseTimeout = 7,
        [Display(Name = "No Vehicle Available")]
        NoVehicleAvailable = 8,
        [Display(Name = "Canceled")]
        Canceled = 9,
        [Display(Name = "Receive Error")]
        ReceiveError = 10,
        [Display(Name = "Busy")]
        Busy = 11,
        [Display(Name = "Suspended")]
        Suspended = 12
    }

    public class RideRequest : TenantAware, ITenantAware, IFranchiseAware
    {
        public RideRequest()
        {
            Children = new HashSet<RideRequest>();
        }

        public int RideRequestId { get; set; }
        public int FranchiseId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Code", Description = "Ride Request Code")]
        public string Code { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Time", Description = "Ride Request Time")]
        public DateTime Time { get; set; }

        [Range(1, 7)] // 4 is excluded because roadside doesn't have requests
        [Display(Name = "Source", Description = "Ride Request Source")]
        public RideSource Source { get; set; }

        [Range(1, 12)]
        [Display(Name = "Status", Description = "Ride Request Status")]
        public RideRequestStatus Status { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Pickup Time", Description = "Ride Pickup Time")]
        public DateTime PickupTime { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Pickup Address", Description = "Ride Request Pickup Address")]
        public string PickupAddress { get; set; }

        [Display(Name = "Pickup Latitude", Description = "Ride Request Pickup Latitude")]
        public double PickupLatitude { get; set; }

        [Display(Name = "Pickup Longitude", Description = "Ride Request Pickup Longitude")]
        public double PickupLongitude { get; set; }

        // Drop-off properties

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Dropoff Time", Description = "Ride Request Dropoff Time")]
        public DateTime DropoffTime { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Dropoff Address", Description = "Ride Request Dropoff Address")]
        public string DropoffAddress { get; set; }

        [Display(Name = "Dropoff Latitude", Description = "Ride Request Dropoff Latitude")]
        public double DropoffLatitude { get; set; }

        [Display(Name = "Dropoff Longitude", Description = "Ride Request Dropoff Longitude")]
        public double DropoffLongitude { get; set; }

        [Display(Name = "Distance", Description = "Ride Request Distance")]
        public long Distance { get; set; }

        [Display(Name = "Duration", Description = "Ride Request Duration")]
        public long Duration { get; set; }

        [Display(Name = "Discount", Description = "Ride Request Discount")]
        public decimal Discount { get; set; }

        [Display(Name = "Fare", Description = "Ride Request Fare")]
        public decimal Fare { get; set; }

        [Required]
        [MaxLength(3)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Fare Currency Code", Description = "Ride Request Fare Currency Code")]
        public string FareCurrencyCode { get; set; }

        [MaxLength(250)]
        [Display(Name = "Remarks", Description = "Ride Remarks")]
        public string Remarks { get; set; }

        [Display(Name = "Customer", Description = "Customer Id")]
        public int CustomerId { get; set; }

        [Display(Name = "Ride Type", Description = "Ride Type Id")]
        public int RideTypeId { get; set; }

        [Display(Name = "Driver", Description = "Driver Id")]
        public int? DriverId { get; set; }

        [Display(Name = "Vehicle", Description = "Vehicle Id")]
        public int? VehicleId { get; set; }

        [Display(Name = "Parent", Description = "Parent Id")]
        public int? ParentId { get; set; }

        [Display(Name = "Option Document", Description = "Ride Request Option Document")]
        public string OptionDocument { get; set; }

        [Display(Name = "No Dropoff Set", Description = "Ride Request no dropoff set")]
        public bool NoDropoffSet { get; set; }

        [Display(Name = "Scheduled For Later", Description = "Ride Request Scheduled For Later")]
        public bool ScheduledForLater { get; set; }

        [Display(Name = "Has Reservation Flag", Description = "Has Ride Request Reservation Flag")]
        public bool HasReservationFlag { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Promo Code", Description = "Ride Request Promo Code")]
        public string PromoCode { get; set; }

        [MaxLength(50)]
        [Display(Name = "Created By", Description = "Ride Request Created By")]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Created Date", Description = "Ride Request Created Date")]
        public DateTime CreatedDate { get; set; }

        [MaxLength(50)]
        [Display(Name = "Modified By", Description = "Ride Request Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Modified Date", Description = "Ride Request Modified Date")]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "Last Status Updated By", Description = "Ride Request Last Status Updated By")]
        public string LastStatusUpdatedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Last Status Updated Time", Description = "Ride Request Last Status Updated Time")]
        public DateTime LastStatusUpdatedTime { get; set; }

        [Display(Name = "Integration Id", Description = "Vehicle Integration Id")]
        public int? IntegrationId { get; set; }

        [NotMapped]
        public RideRequestOptions Options
        {
            get
            {
                if (OptionDocument != null)
                {
                    return JsonConvert.DeserializeObject<RideRequestOptions>(OptionDocument);
                }

                return new RideRequestOptions();
            }
            set
            {
                OptionDocument = CustomJsonConvert.ToCamelCase(value, Formatting.None);
            }
        }

        public virtual Customer Customer { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual RideType RideType { get; set; }
        public virtual RideRequest Parent { get; set; }
        public virtual ICollection<RideRequest> Children { get; set; }
    }
}