
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public class Alert : TenantAware, ITenantAware, IFranchiseAware
    {
        public Alert()
        {
            AlertBlobs = new HashSet<AlertBlob>();
            AlertActivities = new HashSet<AlertActivity>();
        }

        public int AlertId { get; set; }
        public int FranchiseId { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Open Date Time", Description = "Alert Open Date Time")]
        public DateTime OpenDateTime { get; set; }

        [Display(Name = "Latitude", Description = "Alert Open Latitude")]
        public double OpenLatitude { get; set; }

        [Display(Name = "Longitude", Description = "Alert Open Longitude")]
        public double OpenLongitude { get; set; }

        [Display(Name = "Open Speed", Description = "Alert Open Speed")]
        public double OpenSpeed { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Last Date Time", Description = "Alert Last Date Time")]
        public DateTime LastDateTime { get; set; }

        [Display(Name = "Latitude", Description = "Alert Last Latitude")]
        public double LastLatitude { get; set; }

        [Display(Name = "Longitude", Description = "Alert Last Longitude")]
        public double LastLongitude { get; set; }

        [Display(Name = "Last Speed", Description = "Alert Last Speed")]
        public double LastSpeed { get; set; }

        [Display(Name = "Repeat Count", Description = "Alert Repeat Count")]
        public int RepeatCount { get; set; }

        [Display(Name = "Alert Rule", Description = "Alert Rule Id")]
        public int AlertRuleId { get; set; }

        [Display(Name = "Driver", Description = "Driver Id")]
        public int? DriverId { get; set; }

        [Display(Name = "Resolution State", Description = "Resolution State Id")]
        public int ResolutionStateId { get; set; }

        [Display(Name = "Vehicle", Description = "Vehicle Id")]
        public int? VehicleId { get; set; }

        [Display(Name = "Tracked Asset", Description = "Tracked Asset Id")]
        public int? TrackedItemId { get; set; }

        [MaxLength(50)]
        [Display(Name = "Resolved By", Description = "Alert Resolved By")]
        public string ResolvedBy { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Resolved Date", Description = "Alert Resolved Date")]
        public DateTime? ResolvedDate { get; set; }

        [Display(Name = "Last Escalation Level", Description = "Alert Last Escalation Level")]
        public int LastEscalationLevel { get; set; }

        /// <summary>
        /// Server timestamp of newly triggered alert
        /// </summary>
        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Server Timestamp", Description = "Alert Server Timestamp")]
        public DateTime ServerTimestamp { get; set; }

        /// <summary>
        /// SLA allowed time for triggered alert, can be NULL when there is no SLA
        /// </summary>
        [Display(Name = "SLA Time (sec)", Description = "SLA Time (sec)")]
        public long? SlaTime { get; set; }

        /// <summary>
        /// SLA reponse time from alert "ServerTimestamp" to the first change of resolution state, can be NULL when there is no SLA
        /// </summary>
        [Display(Name = "SLA Response Time (sec)", Description = "SLA Response Time (sec)")]
        public long? SlaResponseTime { get; set; }

        /// <summary>
        /// SLA resolution time from alert "ServerTimestamp" to the moment of closing alert, can be NULL when there is no SLA
        /// </summary>
        [Display(Name = "SLA Resolution Time (sec)", Description = "SLA Resolution Time (sec)")]
        public long? SlaResolutionTime { get; set; }

        /// <summary>
        /// SLA breach time when current time exceeds allowed SLA allowed time, can be NULL when there is no SLA
        /// </summary>
        [Display(Name = "SLA Breach Time (sec)", Description = "SLA Breach Time (sec)")]
        public long? SlaBreachTime { get; set; }

        /// <summary>
        /// True when "SlaBreachTime" is greater than zero, can be NULL when there is no SLA
        /// </summary>
        [Display(Name = "Is SLA Breached", Description = "Is Alert SLA Breached")]
        public bool? IsSlaBreached { get; set; }

        /// <summary>
        /// Alert encoded polyline 
        /// </summary>
        [Required]
        [Display(Name = "Encoded Path", Description = "Alert Encoded Path")]
        public string EncodedPath { get; set; }

        [Display(Name = "Has Blobs", Description = "Has Alert Blobs")]
        public bool HasBlobs { get; set; }

        /// <summary>
        /// Alert timeline 
        /// </summary>
        [Required]
        [Display(Name = "Timeline", Description = "Alert Timeline")]
        public string Timeline { get; set; }

        [Display(Name = "Is False", Description = "Is False Alert")]
        public bool IsFalse { get; set; }

        /// <summary>
        /// Alert JSON which holds action results
        /// </summary>
        [Display(Name = "Document", Description = "Alert Document")]
        public string Document { get; set; }

        /// <summary>
        /// Commulative incident duration in seconds.
        /// </summary>
        [Display(Name = "Duration (sec)", Description = "Alert Duration (sec)")]
        public long Duration { get; set; }

        /// <summary>
        /// Count of registered incidents.
        /// </summary>
        [Required]
        [Display(Name = "Incident Count", Description = "Alert Incident Count")]
        public int IncidentCount { get; set; }

        /// <summary>
        /// Time difference between last date and open date.
        /// </summary>
        [Display(Name = "Period (sec)", Description = "Alert Period (sec)")]
        public long Period { get; set; }

        /// <summary>
        /// Unique reference ID for monitoring purposes
        /// </summary>
        [MaxLength(50)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Ref ID", Description = "Alert Ref ID")]
        public string RefId { get; set; }

        [Display(Name = "Is Violation", Description = "Is Violation Alert")]
        public bool IsViolation { get; set; }

        public virtual AlertRule AlertRule { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual ResolutionState ResolutionState { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual TrackedItem TrackedItem { get; set; }
        public virtual ICollection<AlertBlob> AlertBlobs { get; set; }
        public virtual ICollection<AlertActivity> AlertActivities { get; set; }
    }
}