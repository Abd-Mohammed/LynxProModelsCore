using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class TrackedItemCrumb : TenantAware, ITenantAware
    {
        public long TrackedItemCrumbId { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Time Stamp", Description = "Crumb Time Stamp")]
        public DateTime TimeStamp { get; set; }

        [Display(Name = "Latitude", Description = "Crumb Latitude")]
        public double Latitude { get; set; }

        [Display(Name = "Longitude", Description = "Crumb Longitude")]
        public double Longitude { get; set; }

        [Display(Name = "Altitude (m)", Description = "Crumb Altitude (m)")]
        public double Altitude { get; set; }

        [Display(Name = "Angle", Description = "Crumb Angle")]
        public double Angle { get; set; }

        [Display(Name = "Speed (km/h)", Description = "Crumb Speed (km/h)")]
        public double Speed { get; set; }

        [Display(Name = "HDOP", Description = "Crumb HDOP")]
        public double? Hdop { get; set; }

        [Display(Name = "Distance (m)", Description = "Crumb Distance")]
        public double Distance { get; set; }

        [Display(Name = "Satellites No", Description = "Crumb Satellites No")]
        public int SatellitesNo { get; set; }

        [Display(Name = "GSM Signal", Description = "Crumb GSM Signal")]
        public int? GsmSignal { get; set; }

        [Display(Name = "GSM Operator", Description = "Crumb GSM Operator")]
        public string GsmOperator { get; set; }

        [Display(Name = "Power Supply Voltage (V)", Description = "Crumb Power Supply Voltage (V)")]
        public double? PowerSupplyVoltage { get; set; }

        [Display(Name = "Battery Voltage (V)", Description = "Crumb Battery Voltage (V)")]
        public double? BatteryVoltage { get; set; }

        [Display(Name = "Idling Time (sec)", Description = "Crumb Idling Time (sec)")]
        public int IdlingTime { get; set; }

        [Display(Name = "AIN 01 (V)", Description = "Crumb AIN 01 (V)")]
        public double? Ain01 { get; set; }

        [Display(Name = "AIN 02 (V)", Description = "Crumb AIN 02 (V)")]
        public double? Ain02 { get; set; }

        [Display(Name = "Location Status", Description = "Crumb Location Status")]
        public bool? LocationStatus { get; set; }

        [Display(Name = "Raw Message", Description = "Crumb Raw Message")]
        public string RawMessage { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Server Timestamp", Description = "Crumb Server Timestamp")]
        public DateTime? ServerTimestamp { get; set; }

        [Display(Name = "Tracked Asset", Description = "Tracked Asset Id")]
        public int TrackedItemId { get; set; }

        public virtual TrackedItem TrackedItem { get; set; }
    }
}