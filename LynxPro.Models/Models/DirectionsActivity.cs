
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public enum DirectionsActivityType2
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
        [Display(Name = "Stop")]
        Stop = 8,
    }

    public enum DirectionsActivityStatus2
    {
        [Display(Name = "Scheduled")]
        Scheduled = 1,
        [Display(Name = "Enroute")]
        Enroute = 2,
        [Display(Name = "Succeeded")]
        Succeeded = 3,
        [Display(Name = "Failed")]
        Failed = 4,
        [Display(Name = "Expired")]
        Expired = 5,
        [Display(Name = "Canceled")]
        Canceled = 6,
    }

    public class DirectionsActivity : TenantAware, ITenantAware
    {
        public int DirectionsActivityId { get; set; }

        [Display(Name = "Index", Description = "Activity Index")]
        public int Index { get; set; } // 0 for start, 1 for next even if its the same location

        [Display(Name = "Stop Index", Description = "Activity Stop Index")]
        public int StopIndex { get; set; }

        [Range(1, 8)]
        [Display(Name = "Type", Description = "Activity Type")]
        public DirectionsActivityType2 Type { get; set; }

        [Required]
        [Display(Name = "Address", Description = "Activity Address")]
        public string Address { get; set; }

        [Display(Name = "Latitude", Description = "Activity Latitude")]
        public double Latitude { get; set; }

        [Display(Name = "Longitude", Description = "Activity Longitude")]
        public double Longitude { get; set; }

        [Display(Name = "Radius", Description = "Activity Radius")]
        public double Radius { get; set; }

        [Range(1, 6)]
        [Display(Name = "Status", Description = "Activity Status")]
        public DirectionsActivityStatus2 Status { get; set; }

        [Display(Name = "Result", Description = "Activity Result Id")]
        public int? DirectionsActivityResultId { get; set; }

        [Display(Name = "Arrival Time (sec)", Description = "Activity Arrival Time (sec)")]
        public long? ArrTime { get; set; } // Null for start

        [Display(Name = "Arrival Date Time", Description = "Activity Arrival Date Time")]
        public DateTime? ArrDateTime { get; set; } // Null for start

        [Display(Name = "End Time (sec)", Description = "Activity End Time (sec)")]
        public long? EndTime { get; set; } // Null for end, 0 for start

        [Display(Name = "End Date Time", Description = "Activity End Date Time")]
        public DateTime? EndDateTime { get; set; } // Null for end

        [Display(Name = "Waiting Time (sec)", Description = "Activity Waiting Time (sec)")]
        public long? WaitingTime { get; set; } // null for start and end

        [Display(Name = "Service Time (sec)", Description = "Activity Service Time (sec)")]
        public long? ServiceTime { get; set; } // null for start and end

        [Display(Name = "Distance (m)", Description = "Activity Distance (m)")]
        public long Distance { get; set; }

        // Estimation Properties
        [Display(Name = "Est Arrival Time (sec)", Description = "Activity Est Arrival Time (sec)")]
        public long? EstArrTime { get; set; }  // Null for start

        [Display(Name = "Est Arrival Date Time", Description = "Activity Est Arrival Date Time")]
        public DateTime? EstArrDateTime { get; set; } // Null for start

        [Display(Name = "Est End Time (sec)", Description = "Activity Act End Time (sec)")]
        public long? EstEndTime { get; set; }  // Null for start

        [Display(Name = "Est End Date Time", Description = "Act Activity End Date Time")]
        public DateTime? EstEndDateTime { get; set; } // Null for end

        [Display(Name = "Est Remaining Time (sec)", Description = "Activity Est Remaining Time (sec)")]
        public long? EstRemainingTime { get; set; }

        [Display(Name = "Est Remaining Distance (m)", Description = "Activity Est Remaining Distance (m)")]
        public long? EstRemainingDistance { get; set; }

        [Display(Name = "Est Encoded Path", Description = "Activity Est Encoded Path")]
        public string EstEncodedPath { get; set; }

        [Display(Name = "Est Remaining Encoded Path", Description = "Activity Est Remaining Encoded Path)")]
        public string EstRemainingEncodedPath { get; set; }

        // Actual Properties

        [Display(Name = "Act Arrival Time (sec)", Description = "Activity Act Arrival Time (sec)")]
        public long? ActArrTime { get; set; }

        [Display(Name = "Act Arrival Date Time", Description = "Activity Act Arrival Date Time")]
        public DateTime? ActArrDateTime { get; set; } // Null for start

        [Display(Name = "Act Arrival Latitude", Description = "Activity Act Arrival Latitude")]
        public double? ActArrLatitude { get; set; }

        [Display(Name = "Act ArrivalLongitude", Description = "Activity Act Arrvival Longitude")]
        public double? ActArrLongitude { get; set; }

        [Display(Name = "Act End Time (sec)", Description = "Activity Act End Time (sec)")]
        public long? ActEndTime { get; set; }

        [Display(Name = "Act End Date Time", Description = "Act Activity End Date Time")]
        public DateTime? ActEndDateTime { get; set; } // Null for end

        [Display(Name = "Act End Latitude", Description = "Activity Act End Latitude")]
        public double? ActEndLatitude { get; set; }

        [Display(Name = "Act End Longitude", Description = "Activity Act End Longitude")]
        public double? ActEndLongitude { get; set; }

        [Display(Name = "Act Waiting Time (sec)", Description = "Activity Act Waiting Time (sec)")]
        public long? ActWaitingTime { get; set; }

        [Display(Name = "Act Service Time (sec)", Description = "Activity Act Service Time (sec)")]
        public long? ActServiceTime { get; set; }

        [Display(Name = "Act Distance (m)", Description = "Activity Act Distance (m)")]
        public long? ActDistance { get; set; }

        [MaxLength(10)]
        [Column(TypeName = "VARCHAR")]
        [RegularExpression("[a-zA-Z0-9]{5,10}", ErrorMessage = "The field {0} is invalid.")]
        [Display(Name = "Driver", Description = "Activity Driver")]
        public string Driver { get; set; } // Staff Id

        [MaxLength(50)]
        [Display(Name = "User", Description = "Activity User")]
        public string User { get; set; } // Username for now

        [Display(Name = "Unit", Description = "Unit Id")]
        public int? UnitId { get; set; } // NUll for stops

        [Display(Name = "Is Adhoc", Description = "Adhoc Entity Detail Id")]
        public bool IsAdhoc { get; set; }

        [Display(Name = "Parent Activity", Description = "Parent Activity Id")]
        public int? ParentId { get; set; } // parent of delivery is pickup

        [Display(Name = "Route", Description = "Route Id")]
        public int DirectionsRouteId { get; set; }

        public virtual Unit Unit { get; set; }
        public virtual DirectionsActivity Parent { get; set; }
        public virtual DirectionsActivityResult DirectionsActivityResult { get; set; }
        public bool IsCompleted()
        {
            return Status != DirectionsActivityStatus2.Scheduled && Status != DirectionsActivityStatus2.Enroute;
        }
    }
}