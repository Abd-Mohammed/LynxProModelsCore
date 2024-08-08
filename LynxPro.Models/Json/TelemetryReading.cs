using Newtonsoft.Json;
using System;

namespace LynxPro.Models.Json
{
    public class TelemetryReading
    {
        public TelemetryReading(DateTime timestamp, double value)
        {
            Timestamp = timestamp;
            Value = value;
        }

        [JsonProperty("timestamp", Required = Required.Always)]
        public DateTime Timestamp { get; set; }

        [JsonProperty("value", Required = Required.Always)]
        public double Value { get; set; }
    }
}
