using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class VehicleHos : TenantAware, ITenantAware, ISoftDelete
    {
        public int VehicleId { get; set; }

        /// <summary>
        /// Last normal crumb or manual HOS event time
        /// </summary>
        [Display(Name = "Last Event Time", Description = "Vehicle HOS Time Stamp")]
        public DateTime LastEventTime { get; set; }

        [Display(Name = "Time", Description = "Vehicle HOS Time")]
        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        public DateTime? Time { get; set; }

        [MaxLength(50)]
        [Display(Name = "Location", Description = "Vehicle HOS Location")]
        public string Location { get; set; }

        [Display(Name = "Odometer (m)", Description = "Vehicle HOS Odometer (m)")]
        public long? Odometer { get; set; }

        [Display(Name = "Engine Hours", Description = "Vehicle HOS Engine Hours")]
        public double? EngineHours { get; set; }

        [Display(Name = "Status", Description = "Status Id")]
        public int? StatusId { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual HosStatus Status { get; set; }
    }
}