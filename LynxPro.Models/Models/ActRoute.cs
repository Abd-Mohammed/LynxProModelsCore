using LynxPro.Models.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public enum ActRouteStatus
    {
        [Display(Name = "Ready To Start")]
        ReadyToStart = 1,
        [Display(Name = "Started")]
        Started = 2,
        [Display(Name = "Finished")]
        Finished = 3,
    }

    public class ActRoute : TenantAware, ITenantAware, IFranchiseAware
    {
        public ActRoute()
        {
            ActActivities = new HashSet<ActActivity>();
        }

        public int ActRouteId { get; set; }

        public int FranchiseId { get; set; }

        [Display(Name = "Number", Description = "Route Number")]
        public int Number { get; set; }

        [Display(Name = "Stops No.", Description = "Route Stops No.")]
        public int StopsNo { get; set; }

        [Display(Name = "People No.", Description = "Route People No.")]
        public int PeopleNo { get; set; }

        [Display(Name = "Shipments No.", Description = "Route Shipments No.")]
        public int ShipmentsNo { get; set; }

        [Display(Name = "Services No.", Description = "Route Services No.")]
        public int ServicesNo { get; set; }

        [Display(Name = "Harsh Acceleration Count", Description = "Route Harsh Acceleration Count")]
        public int HarshAccelerationCount { get; set; }

        [Display(Name = "Harsh Braking Count", Description = "Route Harsh Braking Count")]
        public int HarshBrakingCount { get; set; }

        [Display(Name = "ExtremeBraking Count", Description = "Route ExtremeBraking Count")]
        public int ExtremeBrakingCount { get; set; }

        [Display(Name = "Overspeeding Count", Description = "Route Overspeeding Count")]
        public int OverspeedingCount { get; set; }

        [Display(Name = "Idling Count", Description = "Route Idling Count")]
        public int IdlingCount { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Start Time", Description = "Route Start Time")]
        public DateTime? StartTime { get; set; }

        [Display(Name = "Start Address", Description = "Route Start Address")]
        public string StartAddress { get; set; }

        [Display(Name = "Latitude", Description = "Route Start Latitude")]
        public double? StartLatitude { get; set; }

        [Display(Name = "Start Longitude", Description = "Route Start Longitude")]
        public double? StartLongitude { get; set; }

        [Display(Name = "Start Altitude (m)", Description = "Vehicle Start Altitude (m)")]
        public double? StartAltitude { get; set; }

        [Display(Name = "Start Heading", Description = "Vehicle Start Heading")]
        public double? StartHeading { get; set; }

        [Display(Name = "Start HDOP", Description = "Vehicle Start HDOP")]
        public double? StartHdop { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "End Time", Description = "Route End Time")]
        public DateTime? EndTime { get; set; }

        [Display(Name = "End Address", Description = "Route End Address")]
        public string EndAddress { get; set; }

        [Display(Name = "End Latitude", Description = "Route End Latitude")]
        public double? EndLatitude { get; set; }

        [Display(Name = "End Longitude", Description = "Route End Longitude")]
        public double? EndLongitude { get; set; }

        [Display(Name = "End Altitude (m)", Description = "Vehicle End Altitude (m)")]
        public double? EndAltitude { get; set; }

        [Display(Name = "End Heading", Description = "Vehicle End Heading")]
        public double? EndHeading { get; set; }

        [Display(Name = "End HDOP", Description = "Vehicle End HDOP")]
        public double? EndHdop { get; set; }

        [Display(Name = "Distance (m)", Description = "Route Distance (m)")]
        public long? Distance { get; set; }

        [Display(Name = "Transport Time (sec)", Description = "Route Transport Time (sec)")]
        public long? TransportTime { get; set; }

        [Display(Name = "Waiting Time (sec)", Description = "Route Waiting Time (sec)")]
        public long? WaitingTime { get; set; }

        [Display(Name = "IdlingTime (sec)", Description = "Route Harsh Brakes No")]
        public long IdlingTime { get; set; } // Idling should be 0 even when route is ready to start

        [Display(Name = "Completion Time (sec)", Description = "Route Completion Time (sec)")]
        public long? CompletionTime { get; set; }

        [Required]
        [Display(Name = "Encoded Path", Description = "Route Encoded Path")]
        public string EncodedPath { get; set; }

        [Range(1, 3)]
        [Display(Name = "Status", Description = "Route Status")]
        public ActRouteStatus Status { get; set; }

        /// <summary>
        /// Route JSON which holds extra data
        /// </summary>
        [Required]
        [Display(Name = "Document", Description = "Route Document")]
        public string Document { get; set; }

        [Display(Name = "Vehicle", Description = "Vehicle Id")]
        public int VehicleId { get; set; }

        [Display(Name = "Driver", Description = "Driver Id")]
        public int? DriverId { get; set; }

        [NotMapped]
        public ActRouteSource Source { get { return JsonMapper.Map<ActRouteDocument>(Document).Source; } }

        public virtual Vehicle Vehicle { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual ICollection<ActActivity> ActActivities { get; set; }
    }
}