using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace LynxPro.Models.Json
{
    public enum AdasWarning
    {
        None = 0,
        ForwardCollisionWarning = 1,
        PedestrianCollisionWarning = 2,
        LaneDepartureWarning = 3,
        ForwardProximityWarning = 4,
        FrontVehicleStartAlarm = 5,
        CallingWarning = 6,
        SmokingWarning = 7,
        DistractionWarning = 8,
        TiredWarning = 9,
        GsensorCollisionWarning = 10,
    }

    public enum AdasFatigueAlertType
    {
        NoAlert = 0,
        FatigueAlert = 1,
        DistractionAlert = 2,
        NoPortraitAlert = 3
    }

    public class Adas
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("warning", Required = Required.DisallowNull)]
        public AdasWarning? Warning { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("fatigueAlert", Required = Required.DisallowNull)]
        public AdasFatigueAlertType? FatigueAlert { get; set; }

        [JsonProperty("status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Status { get; set; }

        [JsonProperty("frontVehicleCount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int? FrontVehicleCount { get; set; }

        [JsonProperty("pedestrianCount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int? PedestrianCount { get; set; }

        [JsonProperty("frontVehicleInfo", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<VehicleInfo> FrontVehicleInfo { get; set; }

        [JsonProperty("pedestrianInfo", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<VehicleInfo> PedestrianInfo { get; set; }
    }

    public class VehicleInfo
    {
        [JsonProperty("x", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double X { get; set; }

        [JsonProperty("y", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double Y { get; set; }
    }
}