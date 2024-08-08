using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace LynxPro.Models.Json
{
    [Flags]
    public enum WarehouseDays
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 4,
        Thursday = 8,
        Friday = 16,
        Saturday = 32,
        Sunday = 64
    }

    public class WarehouseSettings
    {
        [JsonProperty("location", Required = Required.Always)]
        public WarehouseLocation Location { get; set; }

        [JsonProperty("schedule", Required = Required.Always)]
        public WarehouseSchedule Schedule { get; set; }
    }

    public class WarehouseSchedule
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("day", Required = Required.Always)]
        public WarehouseDays Day { get; set; }

        [JsonProperty("startTime", Required = Required.Always)]
        public TimeSpan StartTime { get; set; }

        [JsonProperty("endTime", Required = Required.Always)]
        public TimeSpan EndTime { get; set; }
    }

    public class WarehouseLocation
    {
        [JsonProperty("latitude", Required = Required.Always)]
        public double Latitude { get; set; }

        [JsonProperty("longitude", Required = Required.Always)]
        public double Longitude { get; set; }
    }
}