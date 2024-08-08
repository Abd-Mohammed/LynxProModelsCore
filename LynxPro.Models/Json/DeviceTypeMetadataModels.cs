using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace LynxPro.Models.Json
{
    public enum IdentType
    {
        Imei = 1,
        SerialNo = 2
    }

    [Flags]
    public enum RouteSources
    {
        EngineSwitch = 1,
        Event = 2,
        Location = 4
    }

    public class DeviceTypeMetadata
    {
        //TODO: add commands here

        [JsonProperty("capabilities", Required = Required.Always)]
        public DeviceTypeCapabilities Capabilities { get; set; }

        [JsonProperty("configuration", Required = Required.DisallowNull)]
        public DeviceTypeConfiguration Configuration { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("ident", Required = Required.Always)]
        public IdentType Ident { get; set; }

        [JsonProperty("uiConfiguration", Required = Required.DisallowNull)]
        public UIConfiguration UIConfiguration { get; set; }
    }

    public class DeviceTypeCapabilities
    {
        [JsonProperty("streaming", Required = Required.Always)]
        public bool Streaming { get; set; }

        [JsonProperty("odometerFromCan", Required = Required.DisallowNull)]
        public bool? OdometerFromCan { get; set; }

        [JsonProperty("strictNewest", Required = Required.DisallowNull)]
        public bool? StrictNewest { get; set; }

        /// <summary>
        /// Suppress newest telemetry data when the time difference between timestamp and 
        /// current time is greater than value
        /// </summary>
        [JsonProperty("suppressNewestInHours", Required = Required.DisallowNull)]
        public int? SuppressNewestInHours { get; set; }

        /// <summary>
        /// Suppress oldest telemetry data when the time difference between timestamp and 
        /// current time is greater than value
        /// </summary>
        [JsonProperty("suppressOldestInHours", Required = Required.DisallowNull)]
        public int? SuppressOldestInHours { get; set; }

        [JsonProperty("gpsAccuracy", Required = Required.DisallowNull)]
        public int? GpsAccuracy { get; set; }

        /// <summary>
        /// Flespi channel ID when its provided
        /// </summary>
        [JsonProperty("channelId", Required = Required.DisallowNull)]
        public int? ChannelId { get; set; }

        /// <summary>
        /// Flespi command unique name that can be used in all device protocols i.e. Ruptela: "custom", Teltonika: "codec12"
        /// </summary>
        [JsonProperty("uniqueName", Required = Required.DisallowNull)]
        public string UniqueName { get; set; }

        /// <summary>
        /// Flespi command ID that can be used in some device protocols i.e. Ruptela: 108
        /// </summary>
        [JsonProperty("commandId", Required = Required.DisallowNull)]
        public int? CommandId { get; set; }

        /// <summary>
        /// Messaging middleware queue name that will be used in direct TCP commands
        /// </summary>
        [JsonProperty("queueName", Required = Required.DisallowNull)]
        public string QueueName { get; set; }

        /// <summary>
        /// Base API URL that can be utilized in commands when it's provided
        /// </summary>
        [JsonProperty("api", Required = Required.DisallowNull)]
        public string Api { get; set; }

        /// <summary>
        /// The timezone in which device send telemetatic data
        /// </summary>
        [JsonProperty("timeZoneId", Required = Required.DisallowNull)]
        public string TimeZoneId { get; set; }
    }

    public class DeviceTypeConfiguration
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("routeSource", Required = Required.DisallowNull)]
        public RouteSources? RouteSource { get; set; }

        [JsonProperty("rules", Required = Required.DisallowNull)]
        public IEnumerable<ConfigurationRule> Rules { get; set; }

        [JsonProperty("engineSwitchFallbackToSpeed", Required = Required.DisallowNull)]
        public bool? EngineSwitchFallbackToSpeed { get; set; }
    }

    public class ConfigurationRule
    {
        [JsonProperty("timeRange", Required = Required.Always)]
        public ConfigurationRuleTimeRange TimeRange { get; set; }

        [JsonProperty("fact", Required = Required.Always)]
        public string Fact { get; set; }

        [JsonProperty("operator", Required = Required.Always)]
        public string Operator { get; set; }

        [JsonProperty("value", Required = Required.Always)]
        public string Value { get; set; }

        [JsonProperty("newValue", Required = Required.AllowNull)]
        public string NewValue { get; set; }
    }

    public class ConfigurationRuleTimeRange
    {
        [JsonProperty("from", Required = Required.Always)]
        public TimeSpan From { get; set; }

        [JsonProperty("to", Required = Required.Always)]
        public TimeSpan To { get; set; }
    }

    public class UIConfiguration
    {
        [JsonProperty("displayVision", Required = Required.DisallowNull)]
        public bool? DisplayVision { get; set; }
    }
}