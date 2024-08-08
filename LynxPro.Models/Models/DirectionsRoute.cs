using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public enum DirectionsRouteStatus2
    {
        [Display(Name = "Scheduled")]
        Scheduled = 1,
        [Display(Name = "Delayed")]
        Delayed = 2,
        [Display(Name = "Enroute")]
        Enroute = 3,
        [Display(Name = "Completed")]
        Completed = 4,
        [Display(Name = "Expired")]
        Expired = 5,
        [Display(Name = "Canceled")]
        Canceled = 6
    }

    public enum DirectionsRouteWorkflowStatus
    {
        [Display(Name = "Pending")]
        Pending = 1,
        [Display(Name = "Approved")]
        Approved = 2,
        [Display(Name = "Declined")]
        Declined = 3,
        [Display(Name = "Accepted")]
        Accepted = 4,
        [Display(Name = "Rejected")]
        Rejected = 5
    }

    [Flags]
    public enum DirectionsRouteTypes
    {
        [Display(Name = "Pickup and Delivery")]
        PickupAndDelivery = 1,
        [Display(Name = "Pickup and Drop Off")]
        PickupAndDropOff = 2,
        [Display(Name = "Service")]
        Service = 4,
        [Display(Name = "Shuttle")]
        Shuttle = 8
    }


    public class DirectionsRoute : TenantAware, ITenantAware
    {
        public DirectionsRoute()
        {
            DirectionsActivities = new HashSet<DirectionsActivity>();
        }

        public int DirectionsRouteId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Number", Description = "Route Number")]
        public string Number { get; set; } // It can get a random number or take it from master route i.e. bus route 149

        [Display(Name = "Stop Count", Description = "Route Stop Count")]
        public int StopCount { get; set; } // based on loc and distance

        [Display(Name = "Adhoc Stop Count", Description = "Route Adhoc Stop Count")]
        public int AdhocStopCount { get; set; }

        [Display(Name = "Unit Count", Description = "Route Unit Count")]
        public int UnitCount { get; set; } // unique shipments, people or any other type

        [Display(Name = " Adhoc Unit Count", Description = "Route Adhoc Unit Count")]
        public int AdhocUnitCount { get; set; }

        [Range(1, 6)]
        [Display(Name = "Status", Description = "Route Status")]
        public DirectionsRouteStatus2 Status { get; set; }

        [Range(1, 5)]
        [Display(Name = "Workflow Status", Description = "Route Workflow Status")]
        public DirectionsRouteWorkflowStatus WorkflowStatus { get; set; }

        [Range(1, 15)]
        [Display(Name = "Type", Description = "Route Type")]
        public DirectionsRouteTypes Type { get; set; }

        [MaxLength(500)]
        [Display(Name = "Workflow Metadata", Description = "Route Workflow Metadata")]
        public string WorkflowMetadata { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Start Date", Description = "Route Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Start Address", Description = "Route Start Address")]
        public string StartAddress { get; set; }

        [Display(Name = "Start Latitude", Description = "Route Start Latitude")]
        public double StartLatitude { get; set; }

        [Display(Name = "Start Longitude", Description = "Route Start Longitude")]
        public double StartLongitude { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "End Date", Description = "Route End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "End Address", Description = "Route End Address")]
        public string EndAddress { get; set; }

        [Display(Name = "End Latitude", Description = "Route End Latitude")]
        public double EndLatitude { get; set; }

        [Display(Name = "End Longitude", Description = "Route End Longitude")]
        public double EndLongitude { get; set; }

        [Display(Name = "Distance (m)", Description = "Route Distance (m)")]
        public long Distance { get; set; }

        [Display(Name = "Transport Time (sec)", Description = "Route Transport Time (sec)")]
        public long TransportTime { get; set; }

        [Display(Name = "Waiting Time (sec)", Description = "Route Waiting Time (sec)")]
        public long WaitingTime { get; set; }

        [Display(Name = "Service Time (sec)", Description = "Route Service Time (sec)")]
        public long ServiceTime { get; set; }

        [Display(Name = "Completion Time (sec)", Description = "Route Completion Time (sec)")]
        public long CompletionTime { get; set; }

        [Display(Name = "Encoded Path", Description = "Route Encoded Path")]
        public string EncodedPath { get; set; }

        [Display(Name = "Vehicle", Description = "Vehicle Id")]
        public int? VehicleId { get; set; }

        [Display(Name = "Driver", Description = "Driver Id")]
        public int? DriverId { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Last Scheduled Date", Description = "Route Last Scheduled Date")]
        public DateTime LastScheduledDate { get; set; }

        // Estimation Properties
        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Est End Date", Description = "Route Est End Date")]
        public DateTime? EstEndDate { get; set; }

        // Actual Properties
        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Act Start Date", Description = "Route Act Start Date")]
        public DateTime? ActStartDate { get; set; }

        [Display(Name = "Act Start Latitude", Description = "Route Act Start Latitude")]
        public double? ActStartLatitude { get; set; }

        [Display(Name = "Act Start Longitude", Description = "Route Act Start Longitude")]
        public double? ActStartLongitude { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Act End Date", Description = "Route Act End Date")]
        public DateTime? ActEndDate { get; set; }

        [Display(Name = "Act End Latitude", Description = "Route Act End Latitude")]
        public double? ActEndLatitude { get; set; }

        [Display(Name = "Act End Longitude", Description = "Route Act End Longitude")]
        public double? ActEndLongitude { get; set; }

        [Display(Name = "Act Distance (m)", Description = "Route Act Distance (m)")]
        public long ActDistance { get; set; }

        [Display(Name = "Act Transport Time (sec)", Description = "Route Act Transport Time (sec)")]
        public long ActTransportTime { get; set; }

        [Display(Name = "Act Waiting Time (sec)", Description = "Route Act Waiting Time (sec)")]
        public long ActWaitingTime { get; set; } // probably zero, unless dictated somehow by clicks

        [Display(Name = "Act Service Time (sec)", Description = "Route Act Service Time (sec)")]
        public long ActServiceTime { get; set; }

        [Display(Name = "Act Completion Time (sec)", Description = "Route Act Completion Time (sec)")]
        public long ActCompletionTime { get; set; }

        [Display(Name = "Next Activity Index", Description = "Route Next Activity Index")]
        public int NextActivityIndex { get; set; } // default is zero, perhaps store this to hold next activity for easy track 

        [Display(Name = "Act Encoded Path", Description = "Route Act Encoded Path")]
        public string ActEncodedPath { get; set; } // From start to end (crumbs encoded path)

        public virtual Vehicle Vehicle { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual ICollection<DirectionsActivity> DirectionsActivities { get; set; }
    }
}