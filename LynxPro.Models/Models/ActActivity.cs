using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public enum ActActivityType
    {
        [Display(Name = "Start")]
        Start = 1,
        [Display(Name = "End")]
        End = 2,
        [Display(Name = "Service")]
        Service = 3,
        [Display(Name = "Pickup")]
        Pickup = 4,
        [Display(Name = "Dropoff")]
        Dropoff = 5,
        [Display(Name = "Pickup Shipment")]
        PickupShipment = 6,
        [Display(Name = "Deliver Shipment")]
        DeliverShipment = 7,
        [Display(Name = " Stop")]
        Stop = 8,
    }

    public class ActActivity : TenantAware, ITenantAware
    {
        public int ActActivityId { get; set; }

        [Range(1, 8)]
        [Display(Name = "Type", Description = "Activity Type")]
        public ActActivityType Type { get; set; }

        [Required]
        [Display(Name = "Address", Description = "Activity Address")]
        public string Address { get; set; }

        [Display(Name = "Latitude", Description = "Activity Latitude")]
        public double Latitude { get; set; }

        [Display(Name = "Longitude", Description = "Activity Longitude")]
        public double Longitude { get; set; }

        [Display(Name = "Radius", Description = "Activity Radius")]
        public double Radius { get; set; }

        [Display(Name = "Arrival Time (sec)", Description = "Activity Arrival Time (sec)")]
        public long? ArrTime { get; set; }

        [Display(Name = "Arrival Time", Description = "Activity Arrival Time")]
        public DateTime? ArrTime2 { get; set; } // Null for start

        [Display(Name = "End Time (sec)", Description = "Activity End Time (sec)")]
        public long? EndTime { get; set; }

        [Display(Name = "End Time", Description = "Activity End Time")]
        public DateTime? EndTime2 { get; set; } // Null for end

        [Display(Name = "Waiting Time (sec)", Description = "Activity Waiting Time (sec)")]
        public long? WaitingTime { get; set; }

        [Display(Name = "Distance (m)", Description = "Activity Distance (m)")]
        public long? Distance { get; set; }

        [Display(Name = "Event Time (sec)", Description = "Activity Event Time (sec)")]
        public DateTime? EventTime { get; set; } // Null for start and end

        [Display(Name = "Travel Time (sec)", Description = "Activity Travel Time (sec)")]
        public long? TravelTime { get; set; } // Null for start, service and end. 0 for pickup

        [Display(Name = "Route", Description = "Route Id")]
        public int ActRouteId { get; set; }

        [Display(Name = "Child Activity", Description = "Child Activity Id")]
        public int? ChildActivityId { get; set; }

        public virtual ActActivity ChildActivity { get; set; }
    }
}