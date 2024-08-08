using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public enum FareMeterStatus
    {
        [Display(Name = "Vacant")]
        Vacant = 1,
        [Display(Name = "On Ride")]
        OnRide = 2,
        [Display(Name = "Active Request")]
        ActiveRequest = 3,
        [Display(Name = "Suspended")]
        Suspended = 4
    }

    public class VehicleRideState : TenantAware, ITenantAware, IFranchiseAware
    {
        [Display(Name = "Vehicle", Description = "Vehicle Id")]
        public int VehicleId { get; set; }
        public int FranchiseId { get; set; }

        [Display(Name = "Last Event Time", Description = "Vehicle Ride Last Event Time")]
        public DateTime LastEventTime { get; set; }

        [Display(Name = "Ride Request", Description = "Ride Request Id")]
        public int? RideRequestId { get; set; }

        [Display(Name = "Ride", Description = "Ride Id")]
        public int? RideId { get; set; }

        [Display(Name = "Last Ride Request", Description = "Last Ride Request Id")]
        public int? LastRideRequestId { get; set; }

        [Display(Name = "Last Succeeded Ride", Description = "Last Succeeded Ride Id")]
        public int? LastSucceededRideId { get; set; }

        [Display(Name = "Last Failed Ride", Description = "Last Failed Ride Id")]
        public int? LastFailedRideId { get; set; }

        [Range(1, 4)]
        [Display(Name = "Meter Status", Description = "Vehicle Meter Status")]
        public FareMeterStatus MeterStatus { get; set; }

        [Display(Name = "Meter Last Contact Time", Description = "Vehicle Meter Last Contact Time")]
        public DateTime MeterLastContactTime { get; set; }

        [Required]
        [MaxLength(2500)]
        [Display(Name = "Meter Telemetry Document", Description = "Vehicle Meter Telemetry Document")]
        public string MeterTelemetryDocument { get; set; }

        [Display(Name = "Integration Id", Description = "Vehicle Integration Id")]
        public int? IntegrationId { get; set; }

        [Display(Name = "Trip Count", Description = "Vehicle Trip Count")]
        public int TripCount { get; set; }

        [Display(Name = "Total Income", Description = "Vehicle Trip Total Income")]
        public decimal TotalIncome { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual Ride Ride { get; set; }
        public virtual RideRequest RideRequest { get; set; }
        public virtual RideRequest LastRideRequest { get; set; }
        public virtual Ride LastSucceededRide { get; set; }
        public virtual Ride LastFailedRide { get; set; }
    }
}