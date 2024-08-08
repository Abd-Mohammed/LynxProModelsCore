using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models.Json
{
    public class RideTrip
    {
        [JsonProperty("lastEvent", Required = Required.DisallowNull)]
        public RideTripEvent LastEvent { get; set; }

        [JsonProperty("summary", Required = Required.DisallowNull)]
        public RideTripSummary Summary { get; set; }

        [JsonProperty("fare", Required = Required.DisallowNull)]
        public RideTripFare Fare { get; set; }

        [JsonProperty("invoice", Required = Required.DisallowNull)]
        public RideTripInvoice Invoice { get; set; }

        [JsonProperty("shift", Required = Required.DisallowNull)]
        public RideTripShift Shift { get; set; }

        [JsonProperty("gps", Required = Required.DisallowNull)]
        public RideTripGps Gps { get; set; }

        [JsonProperty("diagnostics", Required = Required.DisallowNull)]
        public RideDiagnostics Diagnostics { get; set; }

        // TODO: add feed
    }

    [Flags]
    public enum DistanceSource
    {
        Obd = 1,
        Gps = 2,
        Vss = 4
    }

    public enum TripOrigin
    {
        UserAction = 1,
        Command = 2,
        ManagedPolicy = 3
    }

    public class RideTripGps
    {
        [JsonProperty("distance", Required = Required.Always)]
        public double Distance { get; set; }

        [JsonProperty("duration", Required = Required.Always)]
        public double Duration { get; set; }

        [JsonProperty("fare", Required = Required.Always)]
        public decimal Fare { get; set; }
    }

    public class RideDiagnostics
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("distanceSource", Required = Required.Always)]
        public DistanceSource DistanceSource { get; set; }

        [JsonProperty("speedErrorMargin")]
        public decimal? SpeedErrorMargin { get; set; }

        [JsonProperty("springConstantK")]
        public double? SpringConstantK { get; set; }

        [JsonProperty("usbDisconnected")]
        public bool? UsbDisconnected { get; set; }

        [JsonProperty("usbFaultDetected")]
        public bool? UsbFaultDetected { get; set; }

        [JsonProperty("needsAttention")]
        public bool? NeedsAttention { get; set; }

        [JsonProperty("timeAtDisconnect")]
        public DateTime? TimeAtDisconnect { get; set; }

        [JsonProperty("distanceAtDisconnect")]
        public double? DistanceAtDisconnect { get; set; }

        [JsonProperty("durationAtDisconnect")]
        public double? DurationAtDisconnect { get; set; }

        [JsonProperty("fareAtDisconnect")]
        public decimal? FareAtDisconnect { get; set; }

        [JsonProperty("origin")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TripOrigin? Origin { get; set; }

        [JsonProperty("app")]
        public string App { get; set; }
    }

    public class RideTripInvoice
    {
        [JsonProperty("id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("number", Required = Required.Always)]
        public string Number { get; set; }
    }

    public class RideTripEvent
    {
        [JsonProperty("guid", Required = Required.Always)]
        public string Guid { get; set; }
    }

    public class RideTripSummary
    {
        public RideTripSummary()
        {
            TollCharges = new List<RideTripGeofenceCharge>();
            TransitCharges = new List<RideTripGeofenceCharge>();
            ExtraCharges = new List<RideTripExtraCharge>();
            PickupAreas = new List<RideTripArea>();
            DropoffAreas = new List<RideTripArea>();
        }

        [JsonProperty("duration", Required = Required.Always)]
        public double Duration { get; set; }

        [JsonProperty("overpaidDuration", Required = Required.Always)]
        public double OverpaidDuration { get; set; }

        [JsonProperty("durationFee", Required = Required.Always)]
        public decimal DurationFee { get; set; }

        [JsonProperty("overpaidDurationFee", Required = Required.Always)]
        public decimal OverpaidDurationFee { get; set; }

        /// <summary>
        /// Trip paid distance.
        /// </summary>
        [JsonProperty("distance", Required = Required.Always)]
        public double Distance { get; set; }

        /// <summary>
        /// Total distance since last trip.
        /// </summary>
        [JsonProperty("distanceSinceLastTrip", Required = Required.Always)]
        public double DistanceSinceLastTrip { get; set; } // Total distance

        [JsonProperty("overpaidDistance", Required = Required.Always)]
        public double OverpaidDistance { get; set; }

        [JsonProperty("distanceFee", Required = Required.Always)]
        public decimal DistanceFee { get; set; }

        [JsonProperty("overpaidDistanceFee", Required = Required.Always)]
        public decimal OverpaidDistanceFee { get; set; }

        [JsonProperty("maxSpeed", Required = Required.Always)]
        public double MaxSpeed { get; set; }

        [JsonProperty("averageSpeed", Required = Required.Always)]
        public double AverageSpeed { get; set; }

        [JsonProperty("waitTime", Required = Required.Always)]
        public double WaitTime { get; set; }

        [JsonProperty("paidWaitTime", Required = Required.Always)]
        public double PaidWaitTime { get; set; }

        [JsonProperty("waitTimeFee", Required = Required.Always)]
        public decimal WaitTimeFee { get; set; }

        [JsonProperty("netFare", Required = Required.Always)]
        public decimal NetFare { get; set; }

        [JsonProperty("totalFare", Required = Required.Always)]
        public decimal TotalFare { get; set; }

        [JsonProperty("distanceToCustomer", Required = Required.Always)]
        public double DistanceToCustomer { get; set; }

        [JsonProperty("durationToCustomer", Required = Required.Always)]
        public double DurationToCustomer { get; set; }

        [MaxLength(3)]
        [JsonProperty("currencyCode", Required = Required.Always)]
        public string CurrencyCode { get; set; }

        [JsonProperty("polyline", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Polyline { get; set; }

        [JsonProperty("roadSpeedLimitExceeded", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? RoadSpeedLimitExceeded { get; set; }

        [JsonProperty("tollCharges", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<RideTripGeofenceCharge> TollCharges { get; set; }

        [JsonProperty("transitCharges", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<RideTripGeofenceCharge> TransitCharges { get; set; }

        [JsonProperty("extraCharges", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<RideTripExtraCharge> ExtraCharges { get; set; }

        [JsonProperty("pickupAreas", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<RideTripArea> PickupAreas { get; set; }

        [JsonProperty("dropoffAreas", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<RideTripArea> DropoffAreas { get; set; }
    }

    public class RideTripEventPosition
    {
        [Range(-90, 90)]
        [JsonProperty("latitude", Required = Required.Always)]
        public double Latitude { get; set; }

        [Range(-180, 180)]
        [JsonProperty("longitude", Required = Required.Always)]
        public double Longitude { get; set; }
    }

    public class RideTripGeofenceCharge
    {
        [JsonProperty("name", Required = Required.DisallowNull)]
        public string Name { get; set; }

        [Required]
        [JsonProperty("time", Required = Required.Always)]
        public DateTime Time { get; set; }

        [Required]
        [JsonProperty("fee", Required = Required.Always)]
        public decimal Fee { get; set; }

        [JsonProperty("position", Required = Required.Always)]
        public RideTripEventPosition Position { get; set; }
    }

    public class RideTripExtraCharge
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [Required]
        [JsonProperty("fee", Required = Required.Always)]
        public decimal Fee { get; set; }
    }

    public class RideTripFare
    {
        [JsonProperty("city", Required = Required.Always)]
        public string City { get; set; }

        [JsonProperty("baseFare", Required = Required.Always)]
        public decimal BaseFare { get; set; }

        [JsonProperty("costPerMinute", Required = Required.Always)]
        public decimal CostPerMinute { get; set; }

        [JsonProperty("costPerDistance", Required = Required.Always)]
        public decimal CostPerDistance { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("distanceUnit", Required = Required.Always)]
        public FareDistanceUnit DistanceUnit { get; set; }

        [JsonProperty("minimumFare", Required = Required.Always)]
        public decimal MinimumFare { get; set; }

        [JsonProperty("bookingFee", Required = Required.Always)]
        public decimal BookingFee { get; set; }

        [JsonProperty("waitTimeChargePerMinute", Required = Required.Always)]
        public decimal WaitTimeChargePerMinute { get; set; }

        [JsonProperty("waitTimeThreshold", Required = Required.Always)]
        public int WaitTimeThreshold { get; set; }

        [MaxLength(3)]
        [JsonProperty("currencyCode", Required = Required.Always)]
        public string CurrencyCode { get; set; }

        [JsonProperty("rideType", Required = Required.Always)]
        public string RideType { get; set; }

        [JsonProperty("schedule", Required = Required.DisallowNull)]
        public string Schedule { get; set; }
    }

    public class RideTripArea
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }
    }

    public class RideTripPosition
    {
        [JsonProperty("tollIntersected", Required = Required.Always)]
        public bool TollIntersected { get; set; }

        [JsonProperty("transitIntersected", Required = Required.Always)]
        public bool TransitIntersected { get; set; }
    }

    public class RideTripShift
    {
        [JsonProperty("id", Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty("number", Required = Required.Always)]
        public string Number { get; set; }
    }
}