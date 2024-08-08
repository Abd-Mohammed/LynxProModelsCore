using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LynxPro.Models.Json
{
    public class TelemetryDocument
    {
        [JsonProperty("hasActiveRoute", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasActiveRoute { get; set; }

        [JsonProperty("hasActiveDriverShift", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasActiveDriverShift { get; set; }

        [JsonProperty("shiftStartTime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ShiftStartTime { get; set; }

        [JsonProperty("lastDriverEventTime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? LastDriverEventTime { get; set; }

        [JsonProperty("lastRouteEventTime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? LastRouteEventTime { get; set; }

        [JsonProperty("fuelLevel", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public TelemetryReading FuelLevel { get; set; }

        [JsonProperty("fuelVolume", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public TelemetryReading FuelVolume { get; set; }

        [JsonProperty("fuelConsumed", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public TelemetryReading FuelConsumed { get; set; }

        [JsonProperty("positiveFuelLevel", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public TelemetryReading PositiveFuelLevel { get; set; }

        [JsonProperty("positiveFuelVolume", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public TelemetryReading PositiveFuelVolume { get; set; }

        [JsonProperty("positiveFuelConsumed", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public TelemetryReading PositiveFuelConsumed { get; set; }

        // Temperature Sensors

        [JsonProperty("temperatureSensor01", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? TemperatureSensor01 { get; set; }

        [JsonProperty("temperatureSensor02", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? TemperatureSensor02 { get; set; }

        [JsonProperty("temperatureSensor03", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? TemperatureSensor03 { get; set; }

        [JsonProperty("temperatureSensor04", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? TemperatureSensor04 { get; set; }

        [JsonProperty("ahtTemperature", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? AhtTemperature { get; set; }

        // EV Reads

        [JsonProperty("driverSeatBeltBuckled", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? DriverSeatBeltBuckled { get; set; }

        [JsonProperty("passengerSeatBeltBuckled", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? PassengerSeatBeltBuckled { get; set; }

        [JsonProperty("backSeatBeltBuckled", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? BackSeatBeltBuckled { get; set; }

        [JsonProperty("distanceToEmpty", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? DistanceToEmpty { get; set; }

        [JsonProperty("evBatteryLevel", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? EVBatteryLevel { get; set; }

        [JsonProperty("simImsi", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string SimImsi { get; set; }

        [JsonProperty("simIccid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string SimIccid { get; set; }

        [JsonProperty("passengerCount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int? PassengerCount { get; set; }

        [JsonProperty("speedReadings", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<TelemetryReading> SpeedReadings { get; set; }

        [JsonProperty("hotspot", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Hotspot Hotspot { get; set; }
    }
}