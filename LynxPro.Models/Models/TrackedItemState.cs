using System;
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class TrackedItemState : TenantAware, ITenantAware
    {
        public int TrackedItemId { get; set; }

        [Display(Name = "Time Stamp", Description = "Tracked Asset Time Stamp")]
        public DateTime TimeStamp { get; set; }

        [Display(Name = "Latitude", Description = "Tracked Asset Latitude")]
        public double Latitude { get; set; }

        [Display(Name = "Longitude", Description = "Tracked Asset Longitude")]
        public double Longitude { get; set; }

        [Display(Name = "Altitude", Description = "Crumb Altitude")]
        public double Altitude { get; set; }

        [Display(Name = "Angle", Description = "Tracked Asset Angle")]
        public double Angle { get; set; }

        [Display(Name = "Speed (km/h)", Description = "Tracked Asset Speed (km/h)")]
        public double Speed { get; set; }

        [Display(Name = "HDOP", Description = "Tracked Asset HDOP")]
        public double? Hdop { get; set; }

        [Display(Name = "Distance (m)", Description = "Tracked Asset Distance (m)")]
        public double Distance { get; set; }

        [Display(Name = "Satellites No", Description = "Tracked Asset Satellites No")]
        public int SatellitesNo { get; set; }

        [Display(Name = "GSM Signal", Description = "Tracked Asset GSM Signal")]
        public int? GsmSignal { get; set; }

        [Display(Name = "GSM Operator", Description = "Tracked Asset GSM Operator")]
        public string GsmOperator { get; set; }

        [Display(Name = "Power Supply Voltage (V)", Description = "Tracked Asset Power Supply Voltage (V)")]
        public double? PowerSupplyVoltage { get; set; }

        [Display(Name = "Battery Voltage (V)", Description = "Device Battery Voltage (V)")]
        public double? BatteryVoltage { get; set; }

        /// <summary>
        /// Previous tracked item idling time
        /// </summary>
        [Display(Name = "Prev Idling Time (sec)", Description = "Tracked Asset Prev Idling Time (sec)")]
        public int PrevIdlingTime { get; set; }

        /// <summary>
        /// Current tracked item idling time
        /// </summary>
        [Display(Name = "Idling Time (sec)", Description = "Tracked Asset Idling Time (sec)")]
        public int IdlingTime { get; set; }

        /// <summary>
        /// Traveled distance between previous timestamp and current timestamp
        /// </summary>
        [Display(Name = "Traveled Distance (m)", Description = "Tracked Asset Traveled Distance (m)")]
        public long TraveledDistance { get; set; }

        [Display(Name = "Open Critical Alerts Count", Description = "Tracked Asset Open Critical Alerts Count")]
        public int OpenCriticalAlertsCount { get; set; }

        [Display(Name = "Open Warning Alerts Count", Description = "Tracked Asset Open Warning Alerts Count")]
        public int OpenWarningAlertsCount { get; set; }

        [Display(Name = "Open Information Alerts Count", Description = "Tracked Asset Open Information Alerts Count")]
        public int OpenInformationAlertsCount { get; set; }

        [Display(Name = "Open Alerts Count", Description = "Tracked Asset Open Alerts Count")]
        public int OpenAlertsCount { get; set; }

        [Display(Name = "Has No GPS Signal", Description = "Tracked Asset Has No GPS Signal")]
        public bool HasNoGpsSignal { get; set; }

        [Display(Name = "Lat Lng Duplicate Count", Description = "Tracked Asset Lat Lng Duplicate Count")]
        public int LatLngDuplicateCount { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Server Timestamp", Description = "Tracked Asset Server Timestamp")]
        public DateTime ServerTimestamp { get; set; }

        public virtual TrackedItem TrackedItem { get; set; }
    }
}